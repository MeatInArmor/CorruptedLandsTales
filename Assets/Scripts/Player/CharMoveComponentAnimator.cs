using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class CharMoveComponentAnimator : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        //[SerializeField] private float m_moveSpeed;
        [SerializeField] private Character m_character;
        [SerializeField] private float m_rotationSmoothTime = 0.12f;
        private IMoveComponent moveComponent => m_character.moveComponent;
        private static int SpeedId = Animator.StringToHash("Speed");
        
        private float m_rotationVelocity;
        private float m_targetRotation;
        private void Start()
        {
            m_animator = GetComponent<Animator>();
        }

        public void AnimateMove(Vector2 move, float cameraY)
        {
            float inputMagnitude = move.magnitude;
            Debug.Log(inputMagnitude);
            m_animator.SetFloat("Speed", Mathf.Abs(inputMagnitude));
            
            var targetTr = gameObject.transform;

            if (inputMagnitude != 0f)
            {
                Vector3 inputDirection = new Vector3(move.x, 0f, move.y).normalized;
                m_targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraY;
                float rotation = Mathf.SmoothDampAngle(targetTr.eulerAngles.y, m_targetRotation, ref m_rotationVelocity, m_rotationSmoothTime);
                targetTr.rotation = Quaternion.Euler(0f, rotation, 0f);
            }

            Vector3 targetDirection = Quaternion.Euler(0f, m_targetRotation, 0f) * Vector3.forward;
            
            
        }
    }
}
