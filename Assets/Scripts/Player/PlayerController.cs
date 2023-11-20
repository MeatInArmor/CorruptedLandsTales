using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private InputActionAsset m_inputActionAsset;
		[SerializeField] private CharacterController m_characterController;
		[SerializeField] private Transform m_cameraTarget;
		[SerializeField] private Transform m_cameraTransform;
		/*[SerializeField] private EnemyAttack m_attack;*/
		
		[SerializeField] private float m_rotationSmoothTime = 0.12f;
		[SerializeField] private float m_speedChangeRate = 10f;
		[SerializeField] private float m_moveSpeed = 5f;
		[SerializeField] private float m_sprintSpeed = 10f;
		[SerializeField] private float m_speedRotation = 200f;
		[SerializeField] private float m_topClamp = 70f;
		[SerializeField] private float m_bottomClamp = -9f;

		private float m_cameraTargetYaw;
		private float m_cameraTargetPitch;
		private float m_rotationVelocity;
		private float m_targetRotation;
		
		private InputActionMap m_playerMap;
		private InputAction m_moveAction;
		private InputAction m_lookAction;
		/*private InputAction m_attackAction;*/


		private void Awake()
		{
			m_playerMap = m_inputActionAsset.FindActionMap("Player");
			m_moveAction = m_playerMap.FindAction("Move");
			m_lookAction = m_playerMap.FindAction("Look");
			/*m_attackAction = m_playerMap.FindAction("Fire");*/
		}

		private void OnEnable()
		{
			m_playerMap.Enable();
			//m_attackAction.performed += context => m_attack.Shoot();
		}

		private void OnDisable()
		{
			m_playerMap.Disable();
			//m_attackAction.performed -= context => m_attack.Shoot();
		}

		private void Update()
		{
			Vector2 move = m_moveAction.ReadValue<Vector2>();
			Move(move, false);
		}

		private void LateUpdate()
		{
			Vector2 look = m_lookAction.ReadValue<Vector2>();
			CameraRotation(look);
		}

		private void Move(Vector2 move, bool isSprint)
		{
			
			// проблема ротейшна, хочу сделать чтобы поворачивался только при движении
			float targetSpeed = 0f;
			float speed = 0;
			float inputMagnitude = move.magnitude; //длина вектора, чем больше длина тем больше скорость
												   //есть еще rb.velocity возвращает вектор сколько единиц проходим
												   //по каждой переменной, если использовать rb.velocity.magnitude
												   //то получаем скорость

			if (inputMagnitude != 0)
			{
				targetSpeed = isSprint ? m_sprintSpeed : m_moveSpeed;
			}

			var characterVelocity = m_characterController.velocity; //вектор скорости по каждой координате
			float currentHorizontalSpeed = new Vector3(characterVelocity.x, 0f, characterVelocity.z).magnitude; //длина вектора

			const float speedOffset = 0.1f;

			if (currentHorizontalSpeed < targetSpeed - speedOffset || 
			    currentHorizontalSpeed > targetSpeed + speedOffset)
			{
				//при помощи Lerp потихоньку увеличиваем скорость между скоростью в настоящий момент и таргетом
				//?targetSpeed * inputMagnitude? 
				speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * m_speedChangeRate);

				//round speed to 3 decimal places
				speed = Mathf.Round(speed * 1000f) / 1000f;
			}
			else
			{
				speed = targetSpeed;
			}
			
			var targetTr = m_characterController.transform;
			
			
			if (inputMagnitude != 0f)
			{
				//новый нормализованный вектор с длинной 1 но с тем же направлением 
				Vector3 inputDirection = new Vector3(move.x, 0f, move.y).normalized;
				
				//посчитали тангенс между x и z, перевели в градусы и добавили ротейшн по камере
				//тангенс чтобы понять направление взгляда через инпут мыши 
				m_targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + m_cameraTransform.eulerAngles.y;

                //вычисляем ротейшн
                //что то типа лерпа но для градусов
                //m_rotationVelocity - погрешность, вспомогательный вектор
                float rotation = Mathf.SmoothDampAngle(targetTr.eulerAngles.y, m_targetRotation, ref m_rotationVelocity, m_rotationSmoothTime);
				
				//меняем сам ротейшн
				targetTr.rotation = Quaternion.Euler(0f, rotation, 0f);
			}
			
			//получили направление из предыдущих вычислений и применили move
			Vector3 targetDirection = Quaternion.Euler(0f, m_targetRotation, 0f) * Vector3.forward;
			Vector3 vertical = new Vector3(0f, Physics.gravity.y * Time.deltaTime, 0f);
			Vector3 horizontal = targetDirection.normalized * (speed * Time.deltaTime);
			m_characterController.Move(horizontal + vertical);
		}

		private void CameraRotation(Vector2 look)
		{
			const float threshold = 0.01f;
			
			// если вектор поворота больше трешхолда то начинаем что то менять
			if (look.sqrMagnitude >= threshold)
			{
				float deltaTimeMultiplier = m_speedRotation * Time.deltaTime;

				m_cameraTargetYaw += look.x * deltaTimeMultiplier; //поворот влево вправо
				m_cameraTargetPitch += look.y * deltaTimeMultiplier; //наклон вперед назад
			}
			
			//ограничение камеры по x и y 
			m_cameraTargetYaw = ClampAngle(m_cameraTargetYaw, float.MinValue, float.MaxValue);
			m_cameraTargetPitch = ClampAngle(m_cameraTargetPitch, m_bottomClamp, m_topClamp);
			
			m_cameraTarget.rotation = Quaternion.Euler(/*0*/ m_cameraTargetPitch, m_cameraTargetYaw, 0f);
		}

		private static float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}

			if (angle > 360f)
			{
				angle -= 360f;
			}
			
			//возвращает либо само значение, если оно входит в промежуток, либо меньшее из чисел если оно меньше,
			//либо большее если больше промежутка
			return Mathf.Clamp(angle, min, max);
		}
	}
}