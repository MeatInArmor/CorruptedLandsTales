using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class Animation_Player_Controller : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;

        public void AnimatorMove(Vector3 move)
        {
            float speed = move.normalized.magnitude;
            m_animator.SetFloat("speed",speed);
            //if ((move.x == 0) && (move.z == 0))
            //{
            //    m_animator.SetBool("IsRunning", false);
            //}
            //else
            //{
            //    m_animator.SetBool("IsRunning", true);
            //}
        }
        public void AnimatorAttack_Stand(bool start)
        {
            if (start == true)
            {
                m_animator.SetBool("IsAttacking", true);
            }
            else
            {
                m_animator.SetBool("IsAttacking", false);
            }
            
        }
        public void AnimatorCastingSpell(bool start)
        {
            if (start == true)
            {
                m_animator.SetBool("IsCastingSpell", true);
            }
            else
            {
                m_animator.SetBool("IsCastingSpell", false);
            }

        }
    }
}
