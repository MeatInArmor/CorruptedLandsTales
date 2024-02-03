using UnityEngine;

namespace CorruptedLandTales
{
    public class AnimationNPC : MonoBehaviour
    {
        private IMoveComponent m_moveComponent;
        private IAttackItem m_attackItem;
        private NavMeshAgentComponent m_navMeshAgentComponent;
        [SerializeField] private Animator m_animator;

        private void Awake()
        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }

            Character character = GetComponentInParent<Character>();
            m_moveComponent = character.moveComponent;
        }

        private void Update()
        {
            if (m_moveComponent != null)
            {
                var speed = m_navMeshAgentComponent.velocity.magnitude;
                m_animator.SetFloat("Speed", speed);
            }
        }
        public void Slash()
        {
            m_animator.SetTrigger("isSlash");
        }
        public void CastSpell()
        {
            m_animator.SetTrigger("isCastSpell");
        }
    }
}
