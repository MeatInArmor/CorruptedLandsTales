using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace CorruptedLandTales
{
    public class FindTargetAction : ActionNode
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {	
        }

        protected override State OnUpdate()
        {
            blackboard.target = context.searcherTarget.FindTarget();
            if (blackboard.target)
            {
                blackboard.moveToPosition = blackboard.target.position;
                return State.Success;
            }
            
            return State.Failure;
        }
    }
}