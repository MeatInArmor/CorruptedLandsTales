using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    [System.Serializable]
    public class AimedOnPlayer : ActionNode
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            var agent = context.agent;
            if (agent.remainingDistance <= blackboard.attackRange)
            {
                context.agent.isStopped = true;
                return State.Success;
            }
            return State.Failure;
        }
    }
}
