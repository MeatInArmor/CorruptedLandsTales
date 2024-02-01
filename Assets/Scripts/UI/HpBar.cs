using UnityEngine;
using UnityEngine.UI;


namespace CorruptedLandTales
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private HealthComponent m_healthComponent;
        [SerializeField] private Image m_fillImage;
        public void Initialize(HealthComponent healthComponent)
        {
            m_healthComponent = healthComponent;                                        // ���� ��������� ������, �� �� � �����
            Refresh();
        }
        private void Awake()
        {
            if(m_healthComponent == null)
                SetComponent();
            Refresh();
        }
        public void SetComponent()
        {
            if (m_healthComponent != null)                                              // ���� ��������� �� ������
            {
                var parentHealthComponent = GetComponentInParent<HealthComponent>();    // ������ ��������� � ��������
                if (parentHealthComponent != null && m_healthComponent == null)         // ���� � ��������� ���� ��������� - ������ ��
                    m_healthComponent = parentHealthComponent;
            }
            else                                                                        // ���� ���, �� ��������� ������ � Player �� �����
                m_healthComponent = GameObject.Find("Player").GetComponent<HealthComponent>();
        }
        private void OnEnable()
        {
            m_healthComponent.onTakeDamage += OnTakeDamage;
            m_healthComponent.onHeal += OnTakeDamage;
            Refresh();
        }
        private void OnTakeDamage(float damage)
        {
            Refresh();
        }

        private void OnHeal(float amount)
        {
            Refresh();
        }
        
        private void Refresh()
        {
            m_fillImage.fillAmount = m_healthComponent.healthPercent;
        }
        private void OnDisable()
        {
            m_healthComponent.onTakeDamage -= OnTakeDamage;
            m_healthComponent.onHeal -= OnTakeDamage;
        }
    }
}
