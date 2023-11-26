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
        [SerializeField] private float m_refreshTime = 0.001f;
        [SerializeField] private float m_speed = 800.0f;
        
        private Quaternion m_toRot = Quaternion.Euler(90f, 0f, 0f);
        private Quaternion m_fromRot = Quaternion.Euler(0f, 0f, 0f);
        
        private Coroutine m_AttackCoroutine;
        private Coroutine m_EndCoroutine;

        private void Awake()
        {
            m_EndCoroutine = StartCoroutine(EndAttack());
        }

        public override void StartUse()
        {
            if (m_EndCoroutine != null)
            {
                StopCoroutine(m_EndCoroutine);
                m_EndCoroutine = null;
                m_AttackCoroutine = StartCoroutine(StartAttack());
            }
        }

        public override void EndUse()
        {
            if (m_AttackCoroutine != null)
            {
                StopCoroutine(m_AttackCoroutine);
                m_AttackCoroutine = null;
                m_EndCoroutine = StartCoroutine(EndAttack());
            }
        }

        
        private IEnumerator StartAttack()
        {
            Debug.Log("StartAttack");
            var waitForSeconds = new WaitForSeconds(m_refreshTime);
            var fromRot = m_fromRot;
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
            Debug.Log("EndAttack");
            var waitForSeconds = new WaitForSeconds(m_refreshTime);
            var toRot = m_toRot;
            do
            {
                transform.localRotation = Quaternion.RotateTowards(toRot, m_fromRot, m_speed*Time.deltaTime);
                toRot = transform.localRotation;
                yield return waitForSeconds;
            } 
            while (true);
        }
        
    }
}
