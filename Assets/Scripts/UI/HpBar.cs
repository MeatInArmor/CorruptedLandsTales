using System.Collections;
using System.Collections.Generic;
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
            m_healthComponent = healthComponent;                                        // если компонент указан, то он и будет
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
            if (m_healthComponent != null)                                              // если компонент не указан
            {
                var parentHealthComponent = GetComponentInParent<HealthComponent>();    // ищется компонент в родителе
                if (parentHealthComponent != null && m_healthComponent == null)         // если в родитееле есть компонент - берётся он
                    m_healthComponent = parentHealthComponent;
            }
            else                                                                        // если нет, то компонент берётся у Player со сцены
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
