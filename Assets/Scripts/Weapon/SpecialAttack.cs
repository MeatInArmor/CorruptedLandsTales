using System;
using System.Collections;
using CorruptedLandTales;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class SpecialAttack : MonoBehaviour
    {
        [SerializeField] private ProjectileComponent m_prefab;
        [SerializeField] private Transform m_muzzle;
        //[SerializeField] private float m_cooldown = 3f;
        [SerializeField] private float m_manaCost;

        private float m_timeLastUsed;
        private ManaComponent m_manaComponent;
        
        public event System.Action onUseSpecial;

        private void Awake()
        {
            m_manaComponent = GetComponentInParent<ManaComponent>();
        }

        public void AnimateSpecialAttack()
        {
            /*float passedTime = Time.time - m_timeLastUsed; 
            if (m_cooldown < passedTime)
            {
                onUseSpecial?.Invoke();
                m_timeLastUsed = Time.time;
            }*/

            if (m_manaComponent.SpendMana(m_manaCost))
            {
                onUseSpecial?.Invoke();
            }
        }

        public void CastSpecialAttack()
        {
            UseSpecialAttack();
        }

        private void UseSpecialAttack()
        {
            Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
        }
    }
}
