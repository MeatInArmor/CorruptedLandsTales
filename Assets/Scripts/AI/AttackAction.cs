using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace TheKiwiCoder {
    [System.Serializable]
    public class AttackAction : ActionNode
    {
        protected override void OnStart()
        {
            /*var atk = context.agent.GetComponent<EnemyAttack>();*/
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            context.enemyAttack.Shoot();
            return State.Success;
        }
    }
}
