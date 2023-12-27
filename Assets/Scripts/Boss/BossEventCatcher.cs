using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class BossEventCatcher : MonoBehaviour
    {
        [SerializeField] private BossAttackManager m_attackManager;

        public void Attack(string typeOfAttack)
        {
            m_attackManager.BossAttack(typeOfAttack);
        }
    }
}
