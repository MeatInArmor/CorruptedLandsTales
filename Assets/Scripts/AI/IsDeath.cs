using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

namespace CorruptedLandTales
{
    public class IsDeath : DecoratorNode
    {
        HealthComponent healthComponent;

        protected override void OnStart()
        {
            if (healthComponent == null)
            {
                healthComponent = context.gameObject.GetComponent<HealthComponent>();
            }
        }

        protected override void OnStop()
        {
			
        }

        protected override State OnUpdate()
        {
            if (healthComponent && healthComponent.isDie)
            {
                return child.Update();
            }

            return State.Failure;
        }
    }
}
