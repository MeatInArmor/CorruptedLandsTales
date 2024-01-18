using System;
using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
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
                Debug.Log($"Spend {manaCost} mana, current mana is {m_currentMana}");
                onSpendMana?.Invoke(manaCost);
                return true;
            }
            else
            {
                Debug.Log($"Try to Spend {manaCost} mana, current mana is {m_currentMana}");
                onSpendMana?.Invoke(manaCost);
                return false;
            }
        }

        public void GainMana(float manaCount)
        {
            m_currentMana = manaCount + m_currentMana > m_manaPool ? (m_manaPool) : manaCount + m_currentMana;
            Debug.Log($"gain {manaCount} mana, manapool is {m_manaPool}, current mana is {m_currentMana}");
            onGainMana?.Invoke(manaCount);

        }
    }
}
