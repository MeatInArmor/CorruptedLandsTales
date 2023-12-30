using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace TheKiwiCoder {

    [System.Serializable]
    public class AnimWaitAction : ActionNode {
        private BossEventCatcher bossEvents;

        protected override void OnStart() {
            if (!bossEvents)
            {
                bossEvents = context.agent.GetComponentInChildren<BossEventCatcher>();
                Debug.Log(bossEvents);
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (bossEvents.flag)
            {
                blackboard.hasChangedTypeOfAttack = false;
                bossEvents.flag = false;
                return State.Success;
            }
            return State.Running;
        }
    }
}
