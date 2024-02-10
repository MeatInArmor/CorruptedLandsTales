using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class ManaUsingButton : MonoBehaviour
    {
        [SerializeField] private ManaComponent m_manaComponent;
        [SerializeField] private Image m_fillImage;
        [SerializeField] private float m_fillMaxAmount = 15f;
        private Color32 m_fullFillColor;
        private float m_fillAmountPercent => m_manaComponent.CurrentMana / m_fillMaxAmount;

        private void Awake()
        {
            if(m_manaComponent == null)
                m_manaComponent = GameObject.Find("Player").GetComponent<ManaComponent>();
            m_fullFillColor = m_fillImage.color;
            Refresh();

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
                m_fillImage.color = Color.white;
            Refresh();
        }
        private void OnGainMana(float mana)
        {
            if (m_manaComponent.CurrentMana >= m_fillMaxAmount)
                m_fillImage.color = m_fullFillColor;
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
