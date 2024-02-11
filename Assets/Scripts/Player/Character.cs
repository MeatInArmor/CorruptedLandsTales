using JetBrains.Annotations;
using UnityEngine;

namespace CorruptedLandTales
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private HealthComponent m_healthComponent;
        [SerializeField] private ManaComponent m_manaComponent;
        [SerializeField] [NotNull] private PlayerCharAnimComponent m_comp;
        
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
            if (data == null)
            {
                return;
            }
            if (attackManager)
            {
                attackManager.Initialize(data.weapon);
            }
            
            if (m_healthComponent != null)
            {
                m_healthComponent.Initialize(data.healthData.maxHealth, data.healthData.health);
            }

            if (m_moveComponent != null)
            {
                m_moveComponent.Init(data.moveData.speed, data.moveData.sprintSpeed);
            }

            if (m_manaComponent != null)
            {
               m_manaComponent.Initialize(data.manaData.manaPool, data.manaData.initMana, data.manaData.manaRegen);
            }

            if (m_comp)
            {
                m_comp.SetSpeed(data.moveData.speed);
            }
        }
    }
}
