using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "StatSO", menuName = "CorruptedLandTales/StatSO")]
    public class StatSO : ScriptableObject
    {
        [SerializeField] private string m_statName;
        [SerializeField] private int m_level;
        [SerializeField] private float m_valuePerLevel;
        [SerializeField] private int m_cost;
        [SerializeField] private int m_costPerLevel;

        public string statName => m_statName;
        public int level => m_level;
        public float valuePerLevel => m_valuePerLevel;
        public int cost => m_cost;
        public int costPerLevel => m_costPerLevel;

        public void IncreaseStatLevel()
        {
            m_level += 1;
        }

        public void IncreaseCost()
        {
            m_cost += m_costPerLevel;
        }

        public void RefreshStats()
        {
            m_level = 0;
            m_cost = m_costPerLevel;
        }

        public void SetCost(int cost)
        {
            m_cost = cost;
        }

        public void SetLevel(int lvl)
        {
            m_level = lvl;
        }
    }
}
