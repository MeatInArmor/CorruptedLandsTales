using UnityEngine;

namespace CorruptedLandTales
{
    public class BossCharacter : MonoBehaviour
    {
        [SerializeField] private BossAttackManager m_attackManager;
        [SerializeField] private HealthComponent m_healthComponent;
        
        private IMoveComponent m_moveComponent;
        public BossAttackManager attackManager => m_attackManager;
        
        public IMoveComponent moveComponent => m_moveComponent;

        public HealthComponent healthComponent => m_healthComponent;
        
        private void Awake()
        {
            if (m_attackManager == null)
            {
                m_attackManager = GetComponent<BossAttackManager>();
            }
            
            if (m_healthComponent == null)
            {
                m_healthComponent = GetComponent<HealthComponent>();
            }

            m_moveComponent = GetComponent<IMoveComponent>();
        }
        
        public void Initialize(BossSO data)
        {
            if (data == null)
            {
                return;
            }
            if (attackManager)
            {
                attackManager.Initialize(data.attacks);
            }
            
            if (m_healthComponent != null)
            {
                m_healthComponent.Initialize(data.healthData.maxHealth, data.healthData.health);
            }

            if (m_moveComponent != null)
            {
                m_moveComponent.Init(data.moveData.speed, data.moveData.sprintSpeed);
            }
        }
    }
}
