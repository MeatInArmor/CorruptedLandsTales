using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CorruptedLandTales
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private HealthComponent m_healthComponent;
        [SerializeField] private ManaComponent m_manaComponent;
        
        private IMoveComponent m_moveComponent;
        public AttackManager attackManager => m_attackManager;
        
        public HealthComponent HealthComponent => m_healthComponent;
        
        public IMoveComponent moveComponent => m_moveComponent;
        
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
        
        public void Initialize(CharacterSO data)
        {
            if (attackManager)
            {
                if(data.weapon)
                {
                    attackManager.Initialize(data.weapon);
                }
                else
                {
                }
            }
            
            if (m_healthComponent)
            {
                m_healthComponent.Initialize(data.healthData.maxHealth, data.healthData.health);
            }

            if (m_moveComponent != null)
            {
                m_moveComponent.Init(data.moveData.speed, data.moveData.sprintSpeed);
            }

            if (m_manaComponent != null)
            {
               m_manaComponent.Initialize(data.manaData.manaPool, data.manaData.initMana);
            }
        }
    }
}
