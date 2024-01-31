using UnityEngine;
using UnityEngine.InputSystem;

namespace CorruptedLandTales
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Character m_character;
		[SerializeField] private InputActionAsset m_inputActionAsset;
		[SerializeField] private Transform m_cameraTransform;
		[SerializeField] private SpecialAttack m_specialAttack;
		[SerializeField] private ItemFinder m_itemFinder;
		[SerializeField] private InteractItemHandler m_itemHandler;
		
		private InputActionMap m_playerMap;
		private InputAction m_moveAction;
		private InputAction m_AttackAction;
		private InputAction m_pickUp;
		private InputAction m_useSpecial;
		private InputAction m_useWeaponSkill;
		private InputAction m_useUpgrade;
		private CharMoveComponent m_charMoveController;
		
		private void Awake()
		{
			m_playerMap = m_inputActionAsset.FindActionMap("Player");
			m_moveAction = m_playerMap.FindAction("Move");
			m_AttackAction = m_playerMap.FindAction("Attack");
			m_pickUp = m_playerMap.FindAction("PickUp");
			m_useSpecial = m_playerMap.FindAction("Special");
			m_useWeaponSkill = m_playerMap.FindAction("WeaponSkill");
			m_useUpgrade = m_playerMap.FindAction("UpgradeWeapon");
			
			m_charMoveController = m_character.GetComponent<CharMoveComponent>();
		}

		private void OnEnable()
		{
			m_playerMap.Enable();
            m_AttackAction.performed += OnAttackInput;
			m_pickUp.performed += OnPickUpInput;
			m_useSpecial.performed += OnUseSpecial;
			m_useWeaponSkill.performed += OnUseWeaponSkill;
			m_useUpgrade.performed += OnUpgradeWeapon;
		}

		private void OnDisable()
		{
			m_playerMap.Disable();
            m_AttackAction.performed -= OnAttackInput;
			m_pickUp.performed -= OnPickUpInput;
			m_useSpecial.performed -= OnUseSpecial;
			m_useWeaponSkill.performed -= OnUseWeaponSkill;
			m_useUpgrade.performed -= OnUpgradeWeapon;
		}
		
		private void OnAttackInput(InputAction.CallbackContext context)
		{
            m_character.attackManager.AnimateUse();
        }
		
		private void OnUseWeaponSkill(InputAction.CallbackContext context)
		{
			m_character.attackManager.UseWeaponSkill();
		}

		private void OnUseSpecial(InputAction.CallbackContext context)
		{
            m_specialAttack.AnimateSpecialAttack();            
        }

		private void OnUpgradeWeapon(InputAction.CallbackContext context)
		{
			m_itemHandler.UpgradeCurrentWeapon();
		}
		
		private void OnPickUpInput(InputAction.CallbackContext context)
		{
			m_itemHandler.HandleItem();
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