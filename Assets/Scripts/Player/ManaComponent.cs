using UnityEngine;

namespace CorruptedLandTales
{
    public class ManaComponent : MonoBehaviour
    {
        [SerializeField] private float m_manaPool;
        [SerializeField] private float m_currentMana = 0;
        public float CurrentMana => m_currentMana;
        public float manaPercent => m_currentMana / m_manaPool;

        public event System.Action<float> onSpendMana;
        public event System.Action<float> onGainMana;

        public void Initialize(float max, float initMp)
        {
            m_manaPool = max;
            m_currentMana = initMp;
            onSpendMana?.Invoke(0);
            onGainMana?.Invoke(0);

        }
        public bool SpendMana(float manaCost)
        {
            if (manaCost <= m_currentMana)
            {
                manaCost = Mathf.Min(manaCost, m_currentMana);
                m_currentMana -= manaCost;
                onSpendMana?.Invoke(manaCost);
                return true;
            }
            else
            {
                onSpendMana?.Invoke(manaCost);
                return false;
            }
        }

        public void GainMana(float manaCount)
        {
            m_currentMana = manaCount + m_currentMana > m_manaPool ? (m_manaPool) : manaCount + m_currentMana;
            onGainMana?.Invoke(manaCount);

        }
    }
}
