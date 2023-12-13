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
        //[SerializeField] private Avatar m_Avataranimator;
        [SerializeField] private Animator m_animator;
        [SerializeField] private Character character;

        private void Awake()
        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }

            //Character character = GetComponentInParent<Character>();
            //m_moveComponent = character.velocity.magnitude;
            //character.healthComponent.onDie += () =>
            //{
            //    m_animator.SetTrigger("Die");
            //};
        }

        private void Update()
        {
            var speed = character.velocity.magnitude;
            m_animator.SetFloat("Speed", speed);
            //if (m_moveComponent != null)
            //{
            //    var speed = character.velocity.magnitude;
            //    m_animator.SetFloat("Speed", speed);
            //}
        }
    }
}
