using CorruptedLandTales;
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
            m_healthComponent = healthComponent;
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
