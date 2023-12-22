using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace TheKiwiCoder {
    [System.Serializable]
    public class AttackAction : ActionNode
    {
        private AttackManager m_attackManager;
        private CharAnimsComponent m_charAnim;
        protected override void OnStart()
        {
            if (!m_attackManager)
            {
                m_attackManager = context.gameObject.GetComponent<AttackManager>();
            }
            if (!m_charAnim)
            {
                m_charAnim = context.gameObject.GetComponentInChildren<CharAnimsComponent>();
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (m_attackManager)
            {
                m_charAnim.Slash();
                m_attackManager.UseWeapon();
                //m_attackManager.EndUseWeapon();
            }
            return State.Success;
        }
    }
}
