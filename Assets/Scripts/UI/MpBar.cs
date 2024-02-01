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
            m_manaComponent = ManaComponent;                                        // ���� ��������� ������, �� �� � �����
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
            if (m_manaComponent != null)                                              // ���� ��������� �� ������
            {
                var parentManaComponent = GetComponentInParent<ManaComponent>();      // ������ ��������� � ��������
                if (parentManaComponent != null && m_manaComponent == null)           // ���� � ��������� ���� ��������� - ������ ��
                    m_manaComponent = parentManaComponent;
            }
            else                                                                      // ���� ���, �� ��������� ������ � Player �� �����
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
