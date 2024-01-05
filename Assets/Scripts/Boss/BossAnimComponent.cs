using UnityEngine;

namespace CorruptedLandTales
{
    public class BossAnimComponent : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Character m_character;
        [SerializeField] private BossAttackManager m_attackManager;
        
        private IMoveComponent moveComponent => m_character.moveComponent;
        private IAttackItem m_attackItem;
        
        private static int SpeedId = Animator.StringToHash("Speed");
        private static int DieId = Animator.StringToHash("Die");
        private static int MeleeAttack1Id = Animator.StringToHash("MeleeAttack1");
        private static int MeleeAttack2Id = Animator.StringToHash("MeleeAttack2");
        private static int MeleeAttack3Id = Animator.StringToHash("MeleeAttack3");
        private static int RangeAttack1Id = Animator.StringToHash("RangeAttack1");
        
        private void Start()
        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }

            if (m_character == null)
            {
                m_character = GetComponent<Character>();
            }
            
            m_character = GetComponentInParent<Character>();
            
            m_attackManager.onMeleeAttack1Action += () =>
            {
                m_animator.SetTrigger(MeleeAttack1Id);
            };
            
            m_attackManager.onRangeAttack1Action += () =>
            {
                m_animator.SetTrigger(RangeAttack1Id);
            };
            
            m_attackManager.onMeleeAttack2Action += () =>
            {
                m_animator.SetTrigger(MeleeAttack2Id);
            };
            
            m_attackManager.onMeleeAttack3Action += () =>
            {
                m_animator.SetTrigger(MeleeAttack3Id);
            };

            m_character.HealthComponent.onDie += () =>
            {
                m_animator.SetTrigger(DieId);
            };
        }

        private void LateUpdate()
        {
            var speed = moveComponent.velocity.magnitude;
            m_animator.SetFloat(SpeedId, speed);
        }
    }
}
