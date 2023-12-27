using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace TheKiwiCoder {
    [System.Serializable]
    public class BossAttackAction : ActionNode
    {
        private BossAttackManager m_attackManager;
        protected override void OnStart()
        {
            if (!m_attackManager)
            {
                m_attackManager = context.gameObject.GetComponent<BossAttackManager>();
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (m_attackManager)
            {
                m_attackManager.BossAttack(blackboard.typeOfAttack);
            }
            return State.Success;
        }
    }
}
