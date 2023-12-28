using System.Collections;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SpecialAttack : MonoBehaviour
    {
        [SerializeField] private ProjectileComponent m_prefab;
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_cooldown = 3f;

        private float m_timeLastUsed;
        
        public event System.Action onUseSpecial;

        public void UseSpecial()
        {
            float passedTime = Time.time - m_timeLastUsed; 
            if (m_cooldown < passedTime)
            {
                onUseSpecial?.Invoke();
                UseSpecialAttack();
                m_timeLastUsed = Time.time;
            }
        }

        private void UseSpecialAttack()
        {
            Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
        }
    }
}
