using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class Bow : AttackItem
    {
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_delay = 3f;
        
        private Coroutine m_fireCoroutine;

        public override void EndUse()
        {
            if(m_fireCoroutine != null)
            {
                StopCoroutine(m_fireCoroutine);
                m_fireCoroutine = null;
            }
        }

        public override bool inInventory { get; set; }

        public override void StartUse()
        {
            m_fireCoroutine = StartCoroutine(StartFire());
        }

        private IEnumerator StartFire()
        {
            var waitForSeconds = new WaitForSeconds(m_delay);

            do
            {
                Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
                yield return waitForSeconds;
            }
            while(true);
        }
    }
}