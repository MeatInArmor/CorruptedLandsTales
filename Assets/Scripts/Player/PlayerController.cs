using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Character m_character;
		[SerializeField] private InputActionAsset m_inputActionAsset;
		[SerializeField] private Transform m_cameraTransform;
		[SerializeField] private SpecialAttack m_specialAttack;
		[SerializeField] private FindItem m_findItem;
		
		private InputActionMap m_playerMap;
		private InputAction m_moveAction;
		private InputAction m_AttackAction;
		private InputAction m_pickUp;
		private InputAction m_useSpecial;
		
		private CharMoveComponent m_charMoveController;
		private CharAnimsComponent m_charAnim;
		
		private void Awake()
		{
			m_playerMap = m_inputActionAsset.FindActionMap("Player");
			m_moveAction = m_playerMap.FindAction("Move");
			m_AttackAction = m_playerMap.FindAction("Attack");
			m_pickUp = m_playerMap.FindAction("PickUp");
			m_useSpecial = m_playerMap.FindAction("Special");
			
			m_charMoveController = m_character.GetComponent<CharMoveComponent>();
			m_charAnim = m_character.GetComponentInChildren<CharAnimsComponent>();
			Debug.Log($"{m_charAnim}");
		}

		private void OnEnable()
		{
			m_playerMap.Enable();

			m_AttackAction.performed += OnAttackInput;
			m_pickUp.performed += OnPickUpInput;
			m_useSpecial.performed += OnUseSpecial;
		}

		private void OnDisable()
		{
			m_playerMap.Disable();

			m_AttackAction.performed -= OnAttackInput;
			m_pickUp.performed -= OnPickUpInput;
			m_useSpecial.performed -= OnUseSpecial;
		}
		
		private void OnAttackInput(InputAction.CallbackContext context)
		{
			m_character.attackManager.UseWeapon();
			m_charAnim.Slash(true);
        }

		private void OnUseSpecial(InputAction.CallbackContext context)
		{
			m_specialAttack.UseSpecial();
		}

		private void OnPickUpInput(InputAction.CallbackContext context)
		{
			m_findItem.PickUp();
		}

		private void Update()
		{
			if (!m_character)
			{
				enabled = false;
				return;
			}
			Vector2 move = m_moveAction.ReadValue<Vector2>();
			Move(move, false);
		}

		

		private void Move(Vector2 move, bool isSprint)
		{
			m_charMoveController.Move(move, isSprint, m_cameraTransform.eulerAngles.y);
		}
		
	}
}