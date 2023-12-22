using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class AnimationNPC : MonoBehaviour
    {
        private IMoveComponent m_moveComponent;
        private IAttackItem m_attackItem;
        private NavMeshAgentComponent m_navMeshAgentComponent;
        //[SerializeField] private Avatar m_Avataranimator;
        [SerializeField] private Animator m_animator;

        private void Awake()
        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }

            Character character = GetComponentInParent<Character>();
            m_moveComponent = character.moveComponent;
            //m_navMeshAgentComponent.velocity.magnitude;
            //m_attackItem = (IAttackItem)character.attackManager;
            /*character.healthComponent.onDie += () =>
            {
                m_animator.SetTrigger("Die");
            };*/
        }

        private void Update()
        {
            //var speed = m_navMeshAgentComponent.velocity.magnitude;
            //m_animator.SetFloat("Speed", speed);
            if (m_moveComponent != null)
            {
                var speed = m_navMeshAgentComponent.velocity.magnitude;
                m_animator.SetFloat("Speed", speed);
            }
            //if (m_attackItem != null)
            //{                
            //    m_animator.SetBool("IsSlash",true);
            //}
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
