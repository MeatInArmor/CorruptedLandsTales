using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    [System.Serializable]
    public class AnimWaitAction : ActionNode {

        public float duration = 1;
        float startTime;

        protected override void OnStart() {
            startTime = Time.time;
            switch (blackboard.typeOfAttack)
            {
                case "meleeAttack1":
                    duration = 2.5f;
                    break;
                case "rangeAttack1":
                    duration = 3.5f;
                    break;
                default:
                    Debug.Log("incorrect attack type");
                    break;
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            
            float timeRemaining = Time.time - startTime;
            if (timeRemaining > duration) {
                return State.Success;
            }
            return State.Running;
        }
    }
}
