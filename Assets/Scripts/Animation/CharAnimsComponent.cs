using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace CorruptedLandTales
{
    public class CharAnimsComponent : MonoBehaviour
    {
        private IMoveComponent m_moveComponent;
        private IAttackItem m_attackItem;
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
            //m_attackItem = (IAttackItem)character.attackManager;
            /*character.healthComponent.onDie += () =>
            {
                m_animator.SetTrigger("Die");
            };*/
        }

        private void Update()
        {
            if (m_moveComponent != null)
            {
                var speed = m_moveComponent.velocity.magnitude;
                m_animator.SetFloat("Speed", speed);
            }
            //if (m_attackItem != null)
            //{                
            //    m_animator.SetBool("IsSlash",true);
            //}
        }
        public void Slash(bool isSlash)
        {
            m_animator.SetBool("isSlash", isSlash);
        }
    }
}
