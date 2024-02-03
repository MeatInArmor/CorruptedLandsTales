using UnityEngine;

namespace CorruptedLandTales
{
    public class UIWorldHpBar : MonoBehaviour
    {
        private Transform m_cameraTransform;

        [SerializeField] private HealthComponent m_healthComponent;
		[SerializeField] private GameObject m_container;

		private void Start()
		{
			m_cameraTransform = Camera.main.transform;//GameObject.Find("MainCamera").transform; //
        }

		private void OnEnable()
		{
			m_healthComponent.onTakeDamage += OnTakeDamage;
			m_healthComponent.onDie += OnDie;
			Refresh();
		}

		private void OnDie()
		{
			m_container.SetActive(false);
		}

		private void OnTakeDamage(float damage)
		{
			Refresh();
		}

		private void Refresh()
		{
			m_container.SetActive(!m_healthComponent.isFullHealth);
		}

		private void OnDisable()
		{
			m_healthComponent.onTakeDamage += OnTakeDamage;
			m_healthComponent.onDie -= OnDie;
		}

		private void LateUpdate()
		{
			transform.rotation = m_cameraTransform.rotation;
		}
    }
}
