using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class EnemyRangeAttack : AttackItem
    {
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private Transform m_muzzle;
        
        public override void StartUse()
        {
            Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
        }

        public override void EndUse()
        {
        }
    }
}
