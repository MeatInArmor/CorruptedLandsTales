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
		
		private InputActionMap m_playerMap;
		private InputAction m_moveAction;
		private InputAction m_lookAction;


		private void Awake()
		{
			m_playerMap = m_inputActionAsset.FindActionMap("Player");
			m_moveAction = m_playerMap.FindAction("Move");
		}

		private void OnEnable()
		{
			m_playerMap.Enable();
		}

		private void OnDisable()
		{
			m_playerMap.Disable();
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