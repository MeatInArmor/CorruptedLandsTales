using CorruptedLandTales;
using ShadowChimera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class ManaUsingButton : MonoBehaviour
    {
        [SerializeField] private ManaComponent m_manaComponent;
        [SerializeField] private Image m_fillImage;
        [SerializeField] private float m_fillMaxAmount = 15f;
        private float m_fillAmountPercent => m_manaComponent.CurrentMana / m_fillMaxAmount;

        public void Initialize(ManaComponent manaComponent)
        {
            m_manaComponent = manaComponent;
        }
        private void OnEnable()
        {
            m_manaComponent.onSpendMana += OnSpendMana;
            m_manaComponent.onGainMana += OnGainMana;
            Refresh();
        }
        private void OnSpendMana(float mana)
        {
            if(m_manaComponent.CurrentMana < m_fillMaxAmount)
                m_fillImage.color = new Color32(255, 255, 255, 255);
            Refresh();
        }
        private void OnGainMana(float mana)
        {
            if (m_manaComponent.CurrentMana > m_fillMaxAmount)
                m_fillImage.color = new Color32(255, 85, 50, 255);
            Refresh();
        }
       
        private void Refresh()
        {
            if(m_manaComponent.CurrentMana <= m_fillMaxAmount)
                m_fillImage.fillAmount = m_fillAmountPercent;
            else
            {
                m_fillImage.fillAmount = m_fillMaxAmount;
            }
        }
        private void OnDisable()
        {
            m_manaComponent.onSpendMana -= OnSpendMana;
            m_manaComponent.onGainMana -= OnGainMana;

        }
    }
}

