using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine;

namespace CorruptedLandTales
{
    public class MeleeAttack : AttackItem
    {
        [SerializeField] private Animation_Player_Controller m_animation_Player_Controller;


        [SerializeField] private float m_refreshTime = 0.001f;
        [SerializeField] private float m_speed = 800.0f;
        
       /* private Quaternion m_toRot = Quaternion.Euler(90f, 0f, 0f);
        private Quaternion m_fromRot = Quaternion.Euler(0f, 0f, 0f);*/
        
        /*private Coroutine m_AttackCoroutine;
        private Coroutine m_EndCoroutine;*/

        private void Awake()
        {
           /* m_EndCoroutine = StartCoroutine(EndAttack());*/
            m_animation_Player_Controller = GetComponent<Animation_Player_Controller>();
        }

        public override void StartUse()
        {
            m_animation_Player_Controller.AnimatorAttack_Stand(true);
            /*if (m_EndCoroutine != null)
            {
                m_animation_Player_Controller.AnimatorAttack_Stand(true);
                StopCoroutine(m_EndCoroutine);
                m_EndCoroutine = null;
                m_AttackCoroutine = StartCoroutine(StartAttack());
            }*/
        }

        public override void EndUse()
        {
            /*if (m_AttackCoroutine != null)
            {
                m_animation_Player_Controller.AnimatorAttack_Stand(false);
                StopCoroutine(m_AttackCoroutine);
                m_AttackCoroutine = null;
                m_EndCoroutine = StartCoroutine(EndAttack());
            }*/
        }


        /*private IEnumerator StartAttack()
        {
            var waitForSeconds = new WaitForSeconds(m_refreshTime);
            var fromRot = m_fromRot;
            //m_animation_Player_Controller.AnimatorAttack_Stand(true);
            do
            {
                transform.localRotation = Quaternion.RotateTowards(fromRot, m_toRot, m_speed*Time.deltaTime);
                fromRot = transform.localRotation;
                yield return waitForSeconds;
            } 
            while (true);
        }
        
        private IEnumerator EndAttack()
        {
            var waitForSeconds = new WaitForSeconds(m_refreshTime);
            var toRot = m_toRot;
            //m_animation_Player_Controller.AnimatorAttack_Stand(false);
            do
            {
                transform.localRotation = Quaternion.RotateTowards(toRot, m_fromRot, m_speed*Time.deltaTime);
                toRot = transform.localRotation;
                yield return waitForSeconds;
            } 
            while (true);
        }*/
        
    }
}
