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
        [SerializeField] private SpecialAttack m_specialAttack;
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private InteractItemHandler m_interactItemHandler;
        [SerializeField] private float m_speedCoef;

        private HealthComponent m_healthcomponent;
        private IAttackItem m_attackItem;
        public void SetSpeed(float speed)
        {
            m_speedCoef = speed;
        }
        
        private void OnAnimatorMove()
        {
            GetComponent<CharacterController>().Move(m_animator.deltaPosition * m_speedCoef);
        }

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

            if (m_specialAttack != null)
            {
                m_specialAttack.onUseSpecial += () =>
                {
                    CastSpell();
                };
            }

            m_character.HealthComponent.onImpact += () =>
            {
                //TODO звуки при попадании
            };

            m_character.HealthComponent.onDie += () =>
            {
                m_animator.SetTrigger("isDie");
            };
            m_attackManager.onUseWeaponSkill += WeaponSkill;
            m_interactItemHandler.onPickUp += PickUp;
        }

        private void CastSpell()
        {
            m_animator.SetTrigger("isCastSpell");
        }
        private void PickUp()
        {
            m_animator.SetBool("isPickUp",true);
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
