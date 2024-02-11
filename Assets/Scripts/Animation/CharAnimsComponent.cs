using UnityEngine;
using TheKiwiCoder;
using ShadowChimera;

namespace CorruptedLandTales
{
    public class CharAnimsComponent : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Character m_character;
        //[SerializeField] private ProjectileCore m_impact;
        //[SerializeField] private CharMoveComponent m_charMoveComponent;
        //[SerializeField] private CharMoveComponentAnimator m_charMoveComponentAnimator;
        //[SerializeField] private SpecialAttack m_specialAttack;
        

        private HealthComponent m_healthcomponent;
        private IMoveComponent moveComponent => m_character.moveComponent;
        private IAttackItem m_attackItem;
        
        private static int SpeedId = Animator.StringToHash("Speed");
        
        private void Start()
        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }

            if (m_character == null)
            {
                m_character = GetComponentInParent<Character>();
            }

            if (m_healthcomponent)
            {                
                m_healthcomponent = GetComponent<HealthComponent>();
            }

            m_character = GetComponentInParent<Character>();            

            m_character.attackManager.onUseAttack += () =>
            {                
                Slash();
            };
            
            m_character.HealthComponent.onImpact += () =>
            {                
                m_animator.SetBool("isImpact", true);
                m_animator.SetBool("isAttack", false);
            };
            
            m_character.HealthComponent.onDie += () =>
            {                
                m_animator.SetTrigger("isDie");
                m_animator.SetBool("isAttack", false);
            };
        }
        //public void OnEndImpact()
        //{
        //    m_animator.SetBool("IsImpact", false);

        //}
        private void LateUpdate()
        {
            var speed = moveComponent.velocity.magnitude;
            m_animator.SetFloat(SpeedId, speed);
        }

        private void Slash()
        {
            m_animator.SetBool("isAttack", true);            
        }
    }
}
