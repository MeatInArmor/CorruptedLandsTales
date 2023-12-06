using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine;

namespace CorruptedLandTales
{
    public class MeleeAttackAnimation : MonoBehaviour
    {
        [SerializeField] private float m_refreshTime = 0.001f;
        [SerializeField] private float m_speed = 400.0f;

        private Quaternion m_toRot = Quaternion.Euler(90f, 0f, 0f);
        private Quaternion m_fromRot = Quaternion.Euler(0f, 0f, 0f);

        private Coroutine m_AttackCoroutine;

        public void AttackAnimation()
        {
            if (m_AttackCoroutine == null)
            {
                m_AttackCoroutine = StartCoroutine(AttackRoutine());
            }
        }

        private IEnumerator AttackRoutine()
        {
            yield return StartCoroutine(StartAttack());
            yield return StartCoroutine(EndAttack());
            m_AttackCoroutine = null;
        }

        private IEnumerator StartAttack()
        {
            var waitForSeconds = new WaitForSeconds(m_refreshTime);
            var fromRot = m_fromRot;
            do
            {
                transform.localRotation = Quaternion.RotateTowards(fromRot, m_toRot, m_speed * Time.deltaTime);
                fromRot = transform.localRotation;
                yield return waitForSeconds;
            } while (Quaternion.Angle(transform.localRotation, m_toRot) > 0.1f);
        }

        private IEnumerator EndAttack()
        {
            var waitForSeconds = new WaitForSeconds(m_refreshTime);
            var toRot = m_toRot;
            do
            {
                transform.localRotation = Quaternion.RotateTowards(toRot, m_fromRot, m_speed * Time.deltaTime);
                toRot = transform.localRotation;
                yield return waitForSeconds;
            } while (Quaternion.Angle(transform.localRotation, m_fromRot) > 0.1f);
        }
    }
}
