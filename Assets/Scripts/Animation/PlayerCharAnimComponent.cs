using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PlayerCharAnimComponent : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Character m_character;
        //[SerializeField] private ProjectileCore m_impact;
        //[SerializeField] private CharMoveComponent m_charMoveComponent;
        //[SerializeField] private CharMoveComponentAnimator m_charMoveComponentAnimator;
        [SerializeField] private SpecialAttack m_specialAttack;
        [SerializeField] private AttackManager m_attackManager;
        //[SerializeField] private HealthComponent m_healthcomponent;

        private HealthComponent m_healthcomponent;
        private IMoveComponent moveComponent => m_character.moveComponent;
        private IAttackItem m_attackItem;

        private static int SpeedId = Animator.StringToHash("Speed");
        //private static int DieId = Animator.StringToHash("Die");
        //private static int SlashId = Animator.StringToHash("Slash");
        //private static int SpecialId = Animator.StringToHash("Special");

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

            /*if (m_charMoveComponent == null)
            {
                m_charMoveComponent = GetComponent<CharMoveComponent>();
            }*/

            if (m_healthcomponent)
            {                
                m_healthcomponent = GetComponent<HealthComponent>();
            }

           /* m_charMoveComponent = GetComponentInParent<CharMoveComponent>();*/

            m_character.attackManager.onUseAttack += () =>
            {
                Slash();
            };


            if (m_specialAttack != null)
            {
                m_specialAttack.onUseSpecial += () =>
                {
                    CastSpell();
                };
            }

            m_character.HealthComponent.onImpact += () =>
            {
                m_animator.SetBool("IsImpact", true);
            };

            m_character.HealthComponent.onDie += () =>
            {
                m_animator.SetTrigger("isDie");
            };

            /* m_character.attackManager.onUseWeaponSkill += () =>
             {
                 m_animator.SetTrigger("isUseWeaponSkill");
             };*/

            m_attackManager.onUseWeaponSkill += WeaponSkill;

            /*
            m_charMoveComponent.onUseDash += () =>
            {
                //m_animator.SetTrigger(SlashId);
                Dash();
            };
            */

        }
        //public void OnEndImpact()
        //{
        //    m_animator.SetBool("IsImpact", false);

        //}
        private void LateUpdate()
        {
            /*var speed = moveComponent.velocity.magnitude;
            m_animator.SetFloat(SpeedId, speed);*/
        }

        private void Slash()
        {
            //m_animator.SetTrigger("isSlash");
        }

        private void CastSpell()
        {
            m_animator.SetTrigger("isCastSpell");
        }

        private void Dash()
        {
            m_animator.SetTrigger("isDash");
        }

        private void WeaponSkill ()
        {
            m_animator.SetTrigger("isUseWeaponSkill");
        }
    }
}
