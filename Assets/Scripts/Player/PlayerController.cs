using System;
using Cinemachine;
using ShadowChimera;
using Unity.VisualScripting;
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
		[SerializeField] private CharMoveComponentAnimator m_charMoveComponentAnimator;
		
		private InputActionMap m_playerMap;
		private InputAction m_moveAction;
		private InputAction m_AttackAction;
		private InputAction m_pickUp;
		private InputAction m_useSpecial;
		//private InputAction m_useWeaponSkill;
		
		private CharMoveComponent m_charMoveController;
		
		private void Awake()
		{
			m_playerMap = m_inputActionAsset.FindActionMap("Player");
			m_moveAction = m_playerMap.FindAction("Move");
			m_AttackAction = m_playerMap.FindAction("Attack");
			m_pickUp = m_playerMap.FindAction("PickUp");
			m_useSpecial = m_playerMap.FindAction("Special");
			//m_useWeaponSkill = m_playerMap.FindAction("WeaponSkill");
			
			m_charMoveController = m_character.GetComponent<CharMoveComponent>();
		}

		private void Start()
		{
			m_character.GetComponent<CharacterController>().enabled = true;
		}

		private void OnEnable()
		{
			m_playerMap.Enable();
            //Dash
            //m_useDash.performed += OnUseDash;
            m_AttackAction.performed += OnAttackInput;
			m_pickUp.performed += OnPickUpInput;
			m_useSpecial.performed += OnUseSpecial;
			//m_useWeaponSkill.performed += OnUseWeaponSkill;
		}

		private void OnDisable()
		{
			m_playerMap.Disable();
            //Dash
            //m_useDash.performed -= OnUseDash;
            m_AttackAction.performed -= OnAttackInput;
			m_pickUp.performed -= OnPickUpInput;
			m_useSpecial.performed -= OnUseSpecial;
			//m_useWeaponSkill.performed -= OnUseWeaponSkill;
		}
		
		private void OnAttackInput(InputAction.CallbackContext context)
		{
            m_character.attackManager.AnimateUse();
        }
		
		/*private void OnUseWeaponSkill(InputAction.CallbackContext context)
		{
			m_character.attackManager.UseWeaponSkill();
		}*/

		private void OnUseSpecial(InputAction.CallbackContext context)
		{
            m_specialAttack.AnimateSpecialAttack();            
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
			m_charMoveComponentAnimator.AnimateMove(move, m_cameraTransform.eulerAngles.y);
		}
	}
}