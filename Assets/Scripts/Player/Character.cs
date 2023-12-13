using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private HealthComponent m_healthComponent;
        
        private IMoveComponent m_moveComponent;
        public AttackManager attackManager => m_attackManager;
        
        public void Initialize(CharacterSO data)
        {
            if (attackManager)
            {
                attackManager.Initialize(data.weapon);
            }
            
            if (m_healthComponent)
            {
                m_healthComponent.Initialize(data.healthData.maxHealth, data.healthData.health);
            }

            if (m_moveComponent != null)
            {
                m_moveComponent.Init(data.moveData.speed, data.moveData.sprintSpeed);
            }
        }

        private void Awake()
        {
            if (m_attackManager == null)
            {
                m_attackManager = GetComponent<AttackManager>();
            }
            
            if (m_healthComponent == null)
            {
                m_healthComponent = GetComponent<HealthComponent>();
            }

            m_moveComponent = GetComponent<IMoveComponent>();
        }
    }
}
