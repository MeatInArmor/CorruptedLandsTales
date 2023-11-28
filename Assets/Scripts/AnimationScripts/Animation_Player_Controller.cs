using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class Animation_Player_Controller : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;

        public void AnimatorMove(Vector2 move)
        {
            if ((move.x == 0) & (move.y == 0))
            {
                m_animator.SetBool("IsRunning", false);
            }
            else
            {
                m_animator.SetBool("IsRunning", true);
            }
        }
    }
}
