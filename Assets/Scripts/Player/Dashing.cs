using System;
using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    public class Dashing : MonoBehaviour
    {
        //[SerializeField] private Transform orientation;
        //[SerializeField] private Transform playercam;
        [SerializeField] private Character m_character;
        [SerializeField] private float m_dashForce = 20.0f;
        //[SerializeField] private float m_dashDuration;
        [SerializeField] private float m_dashcd = 1.0f;
        
        private Rigidbody rb;
        private float m_timeLastUsed;

        private void Start()
        {
        }

        public void Dash()
        {
            float passedTime = Time.time - m_timeLastUsed; 
            if (m_dashcd < passedTime)
            {
                Vector3 forceToApply = transform.forward * m_dashForce;
                rb.AddForce(forceToApply, ForceMode.Impulse);
                m_timeLastUsed = Time.time;
            }
        }
    }
}
