using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CorruptedLandTales
{
    public class MpBar : MonoBehaviour
    {
        [SerializeField] private ManaComponent m_manaComponent;
        [SerializeField] private Image m_fillImage;
        public void Initialize(ManaComponent manaComponent)
        {
            m_manaComponent = manaComponent;
        }
        private void OnEnable()
        {
            m_manaComponent.onSpendMana += OnManaUsing;
            m_manaComponent.onGainMana += OnManaUsing;
            Refresh();
        }
        private void OnManaUsing(float mana)
        {
            Refresh();
        }
        private void Refresh()
        {
            m_fillImage.fillAmount = m_manaComponent.manaPercent;
        }
        private void OnDisable()
        {
            m_manaComponent.onSpendMana -= OnManaUsing;
            m_manaComponent.onGainMana -= OnManaUsing;

        }
    }
}
