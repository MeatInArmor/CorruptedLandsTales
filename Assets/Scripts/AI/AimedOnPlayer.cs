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
            if (blackboard.isAimedOnPlayer)
            {
                context.agent.isStopped = true;
                return State.Success;
            }
            return State.Failure;

        }
    }
}
