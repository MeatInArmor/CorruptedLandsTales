using System.Collections;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SpecialAttack : MonoBehaviour
    {
        [SerializeField] private ProjectileComponent m_prefab;
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_cooldown = 3f;
        [SerializeField] private float m_useDelay = 1.0f;

        private float m_timeLastUsed;
        
        public event System.Action onUseSpecial;

        public void UseSpecial()
        {
            float passedTime = Time.time - m_timeLastUsed; 
            if (m_cooldown < passedTime)
            {
                onUseSpecial?.Invoke();
                StartCoroutine(Waiter());
                //UseSpecialAttack();
                m_timeLastUsed = Time.time;
            }
        }

        private void UseSpecialAttack()
        {
            Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
        }

        private IEnumerator Waiter()
        {
            yield return new WaitForSeconds(m_useDelay);
            UseSpecialAttack();
        }
    }
}
