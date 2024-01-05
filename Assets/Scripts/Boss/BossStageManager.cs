using System;
using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace ShadowChimera
{
    public class BossStageManager : MonoBehaviour
    {
        [SerializeField] private int m_countStages = 2;
        [SerializeField] private HealthComponent m_healthComponent;
        
        private int m_activeStage = 1;
        private float m_healthNextStagePercent;
        private float m_currentPercent;
        public int ActiveStage => m_activeStage;

        private void Start()
        {
            m_healthNextStagePercent = 1.0f - 1.0f / m_countStages;
        }

        private void Update()
        {
            m_currentPercent = m_healthComponent.CurrentHealth / m_healthComponent.MaxHealth;
            if (m_currentPercent < m_healthNextStagePercent && m_healthNextStagePercent < 1)
            {
                m_activeStage += 1;
                m_healthNextStagePercent += m_healthNextStagePercent;
                Debug.Log("Next Stage");
            }
        }
    }
}
