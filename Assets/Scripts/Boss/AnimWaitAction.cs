using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace TheKiwiCoder {

    [System.Serializable]
    public class AnimWaitAction : ActionNode {
        
        public float duration = 1;
        private float startTime;
        private BossEventCatcher bossEvents;

        protected override void OnStart() {
            startTime = Time.time;
            if (!bossEvents)
            {
                bossEvents = context.agent.GetComponentInChildren<BossEventCatcher>();
                Debug.Log(bossEvents);
            }
            /*switch (blackboard.typeOfAttack)
            {
                case "meleeAttack1":
                    duration = 3.7f;
                    Debug.Log($"duration: {duration}");
                    break;
                case "rangeAttack1":
                    duration = 5f;
                    Debug.Log($"duration: {duration}");
                    break;
                default:
                    Debug.Log("incorrect attack type");
                    break;
            }*/
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
            /*float timeRemaining = Time.time - startTime;
            if (timeRemaining > duration) {
                blackboard.hasChangedTypeOfAttack = false;
                return State.Success;
            }*/
            return State.Running;
        }
    }
}
