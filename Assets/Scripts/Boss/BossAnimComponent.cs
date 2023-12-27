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
        private static int MeleeAttack1Id = Animator.StringToHash("MeleeAttack1");
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
            
        }

        private void LateUpdate()
        {
            var speed = moveComponent.velocity.magnitude;
            m_animator.SetFloat(SpeedId, speed);
        }
    }
}
