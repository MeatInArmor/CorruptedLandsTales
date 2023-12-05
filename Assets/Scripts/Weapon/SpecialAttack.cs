using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class SpecialAttack : MonoBehaviour
    {
        //Инициализируем Animation_Player_Controller
        private Animation_Player_Controller m_animation_Player_Controller;

        [SerializeField] private ProjectileComponent m_prefab;
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_cooldown = 3f;

        private float m_timeLastUsed;

        public void UseSpecial()
        {
            //m_animation_Player_Controller.AnimatorCastingSpell(true);
            //m_animation_Player_Controller.AnimatorCastingSpell(false);
            var passedTime = Time.time - m_timeLastUsed; 
            if (m_cooldown < passedTime)
            {
                Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
                m_timeLastUsed = Time.time;
            }
        }
    }
}
