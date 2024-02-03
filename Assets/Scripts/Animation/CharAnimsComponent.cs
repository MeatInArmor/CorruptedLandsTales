using UnityEngine;

namespace CorruptedLandTales
{
    public class CharAnimsComponent : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Character m_character;
        [SerializeField] private CharMoveComponent m_charMoveComponent;
        [SerializeField] private SpecialAttack m_specialAttack;
        
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

            if (m_charMoveComponent == null)
            {
                m_charMoveComponent = GetComponent<CharMoveComponent>();
            }

            if (m_healthcomponent)
            {
                m_healthcomponent = GetComponentInParent<HealthComponent>();
            }

            m_character = GetComponentInParent<Character>();
            m_charMoveComponent = GetComponentInParent<CharMoveComponent>();

            m_character.attackManager.onUseAttack += () =>
            {
                //m_animator.SetTrigger(SlashId);
                Slash();
            };
            
            if (m_specialAttack != null)
            {
                m_specialAttack.onUseSpecial += () =>
                {
                    //m_animator.SetTrigger(SpecialId);
                    CastSpell();
                };
            }
            
            if (m_healthcomponent != null)
            {
                m_healthcomponent.onDie += () =>
                {
                    m_animator.SetTrigger("isDie");
                };
            }
            
            /*
            m_charMoveComponent.onUseDash += () =>
            {
                //m_animator.SetTrigger(SlashId);
                Dash();
            };
            */
            
        }

        private void LateUpdate()
        {
            var speed = moveComponent.velocity.magnitude;
            m_animator.SetFloat(SpeedId, speed);
        }
        
        private void Slash()
        {
            m_animator.SetTrigger("isSlash");
        }
        
        private void CastSpell()
        {
            m_animator.SetTrigger("isCastSpell");
        }

        private void Dash()
        {
            m_animator.SetTrigger("isDash");
        }

    }
}
