using System;
using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.TextCore.Text;

namespace CorruptedLandTales
{
    public class CharAnimsComponent : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Character m_character;
        [SerializeField] private SpecialAttack m_specialAttack;
        
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
                m_character = GetComponent<Character>();
            }
            
            m_character = GetComponentInParent<Character>();
            
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
    }
}
