using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using ShadowChimera;
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
        [SerializeField] private float m_cooldown = 3f;
        [SerializeField] private AudioPlayer m_audioPlayer;
        [SerializeField] private ComboAnimator m_comboAnimator;
        
        private HealthComponent m_healthcomponent;
        private IAttackItem m_attackItem;
        private float m_timeLastUsed;

        public float dashCooldown => m_cooldown;
        public event System.Action onUseDash;
        
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
                m_audioPlayer.PlayAudio("playerImpact");
                m_comboAnimator.attack3();
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
        public void Dash()
        {
            float passedTime = Time.time - m_timeLastUsed; 
            if (m_cooldown < passedTime)
            {
                onUseDash?.Invoke();
                m_animator.SetTrigger("isDash");
                m_timeLastUsed = Time.time;
            }
        }

        private void WeaponSkill ()
        {
            m_animator.SetTrigger("isUseWeaponSkill");
        }
    }
}
