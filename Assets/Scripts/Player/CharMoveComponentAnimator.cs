using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class CharMoveComponentAnimator : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        [SerializeField] private float m_moveSpeed;
        [SerializeField] private Character m_character;
        private IMoveComponent moveComponent => m_character.moveComponent;
        private static int SpeedId = Animator.StringToHash("Speed");
        private void Start()
        {
            m_animator = GetComponent<Animator>();
        }
        private void LateUpdate()
        {
            var m_moveSpeed = moveComponent.velocity.magnitude;
            m_animator.SetFloat(SpeedId, m_moveSpeed);
        }
        void Update()
        {
            //m_moveSpeed = moveComponent.velocity.magnitude;
            //m_animator.SetFloat("Speed", m_moveSpeed);

            float rotationX = Input.GetAxis("Horizontal");


            float rotationY = Input.GetAxis("Vertical");
            
            transform.Rotate(Vector3.up, rotationX);
            //transform.Rotate(Vector3.left, rotationY);
            transform.Rotate(Vector3.down, rotationY);

            //m_animator.SetFloat("Speed", m_moveSpeed);
        }
        
    }
}
