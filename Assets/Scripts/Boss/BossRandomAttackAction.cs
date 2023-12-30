using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace CorruptedLandTales
{
    [System.Serializable]
    public class BossRandomAttackAction : ActionNode
    
    {
        private string[] m_attackTypes;
        protected override void OnStart()
        {
            if (m_attackTypes == null)
            {
                BossAttackManager attackManager = context.agent.GetComponent<BossAttackManager>();
                m_attackTypes = attackManager.GetAttackTypes();
            }
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (!blackboard.hasChangedTypeOfAttack) //нужно доделать вот это под каждую атаку чтобы считывался рендж
            {
                blackboard.typeOfAttack = m_attackTypes[Random.Range(0, m_attackTypes.Length)];
                if (blackboard.typeOfAttack.Contains("range"))
                {
                    blackboard.attackRange = 10.0f;
                }
                else
                {
                    blackboard.attackRange = 6.0f;
                }
                blackboard.hasChangedTypeOfAttack = true;
            }
            return State.Success;
        }
    }
}
