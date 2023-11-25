using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
	public class TopPersonController : MonoBehaviour
	{
		[SerializeField] private Character m_character;
		[SerializeField] private InputActionAsset m_inputActionAsset;
		[SerializeField] private Transform m_cameraTransform;
		[SerializeField] private SpecialAttack m_specialAttack;	
		
		private InputActionMap m_playerMap;
		private InputAction m_moveAction;
		private InputAction m_fireAction;
		private InputAction m_swapWeapon;
		private InputAction m_useSpecial;
		
		private void Awake()
		{
			m_playerMap = m_inputActionAsset.FindActionMap("Player");
			m_moveAction = m_playerMap.FindAction("Move");
			m_fireAction = m_playerMap.FindAction("Fire");
			m_swapWeapon = m_playerMap.FindAction("Swap");
			m_useSpecial = m_playerMap.FindAction("Special");
		}

		private void OnEnable()
		{
			m_playerMap.Enable();

			m_fireAction.started += OnFireInputStarted;
			m_fireAction.canceled += OnFireInputCanceled;
			m_swapWeapon.performed += SwapWeapon;
			m_useSpecial.started += OnUseSpecialStarted;
			m_useSpecial.canceled += OnUseSpecialCanceled;
		}

		private void OnDisable()
		{
			m_playerMap.Disable();

			m_fireAction.started -= OnFireInputStarted;
			m_fireAction.canceled -= OnFireInputCanceled;
			m_useSpecial.started -= OnUseSpecialStarted;
			m_useSpecial.canceled -= OnUseSpecialCanceled;
		}
		
		private void OnFireInputStarted(InputAction.CallbackContext context)
		{
			m_character.attackManager.StartUseWeapon();
		}

		private void OnFireInputCanceled(InputAction.CallbackContext context)
		{
			m_character.attackManager.EndUseWeapon();
		}

		private void SwapWeapon(InputAction.CallbackContext context)
		{
			m_character.attackManager.Next();
		}

		private void OnUseSpecialStarted(InputAction.CallbackContext context)
		{
			m_specialAttack.StartUseSpecial();
		}
		
		private void OnUseSpecialCanceled(InputAction.CallbackContext context)
		{
			m_specialAttack.EndUseSpecial(); // переделать просто под атаку и кд
		}

		private void Update()
		{
			if (m_character == null)
			{
				enabled = false;
				return;
			}
			Vector2 move = m_moveAction.ReadValue<Vector2>();
			Move(move, false);
		}
		
		private void Move(Vector2 move, bool isSprint)
		{
			m_character.Move(move, isSprint, m_cameraTransform.eulerAngles.y);
		}
		
	}
}