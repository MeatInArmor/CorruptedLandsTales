using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace CorruptedLandTales
{
    public class NextPointsAction : ActionNode
    {
        private CharAnimsComponent m_charAnim;
        
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            var newPoint = Random.insideUnitSphere * Random.Range(5,8);
            var enemyPoint = context.gameObject.transform.position;
            // return State.Failure;
            
            blackboard.moveToPosition = enemyPoint - newPoint;
            return State.Success;
        }
    }
}
