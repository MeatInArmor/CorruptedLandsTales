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

        private void Awake()
        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }

            Character character = GetComponentInParent<Character>();
            Debug.Log($"{character}");
            m_moveComponent = character.moveComponent;
            Debug.Log($"{m_moveComponent}");
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
                Debug.Log($"{speed}");
                m_animator.SetFloat("Speed", speed);
            }
        }
    }
}
