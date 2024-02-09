using ShadowChimera;
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
        [SerializeField] private CharMoveComponentAnimator m_charMoveComponentAnimator;
        [SerializeField] private Animator m_animator;
        [SerializeField] private CharacterController m_characterController;
		[SerializeField] private GameObject m_Player;
		[SerializeField] private ComboAnimator m_comboAnimator;

        private InputActionMap m_playerMap;
		private InputAction m_moveAction;
		private InputAction m_AttackAction;
		private InputAction m_pickUp;
		private InputAction m_useSpecial;
		private InputAction m_useWeaponSkill;
		private InputAction m_useUpgrade;
		private CharMoveComponent m_charMoveController;

        private static readonly int HorizontalId = Animator.StringToHash("Horizontal");
        private static readonly int VerticalId = Animator.StringToHash("Vertical");
        
        
        private PlayerInput m_input;

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
			m_cameraTransform = Camera.main.transform;
        }
        private void Start()
        {
            m_character.GetComponent<CharacterController>().enabled = true;
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
			m_comboAnimator.ClickAttack();
        }
		
		private void OnUseWeaponSkill(InputAction.CallbackContext context)
		{
			m_character.attackManager.AnimateWeaponSkill();
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
            var inputMove = m_moveAction.ReadValue<Vector2>();
			//Debug.Log(inputMove);
            var cameraY = m_cameraTransform.localEulerAngles.y;
            var inputMagnitude = inputMove.magnitude;
            //Debug.Log(inputMagnitude);
            if (inputMagnitude > 0)
            {
                float targetRotation = Mathf.Atan2(inputMove.x, inputMove.y) * Mathf.Rad2Deg + cameraY;
                Quaternion toRotation = Quaternion.Euler(0f, targetRotation, 0f);
                //Debug.Log(toRotation);
                m_Player.transform.rotation = Quaternion.RotateTowards(m_Player.transform.rotation, toRotation, 1440 * Time.deltaTime);                
            }

            m_animator.SetFloat(HorizontalId, 0f, 0.05f, Time.deltaTime);
            m_animator.SetFloat(VerticalId, inputMagnitude, 0.05f, Time.deltaTime);
        }
    }
}