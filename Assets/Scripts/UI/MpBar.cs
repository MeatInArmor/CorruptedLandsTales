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
        
        public void Initialize(ManaComponent ManaComponent)
        {
            m_manaComponent = ManaComponent;                                        // если компонент указан, то он и будет
            Refresh();
        }
        private void Awake()
        {
            if (m_manaComponent == null)
                SetComponent();
            Refresh();
        }
        public void SetComponent()
        {
            if (m_manaComponent != null)                                              // если компонент не указан
            {
                var parentManaComponent = GetComponentInParent<ManaComponent>();      // ищется компонент в родителе
                if (parentManaComponent != null && m_manaComponent == null)           // если в родитееле есть компонент - берётся он
                    m_manaComponent = parentManaComponent;
            }
            else                                                                      // если нет, то компонент берётся у Player со сцены
                m_manaComponent = GameObject.Find("Player").GetComponent<ManaComponent>();
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
