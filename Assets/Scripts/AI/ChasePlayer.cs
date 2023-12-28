using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine.Serialization;

[System.Serializable]
public class ChasePlayer : ActionNode
{
	protected override void OnStart()
	{
		context.agent.isStopped = false;
		context.agent.stoppingDistance = blackboard.attackRange;
		context.agent.SetDestination(blackboard.target.position);
	}

	protected override void OnStop()
	{
	}

	protected override State OnUpdate()
	{
		var agent = context.agent;
		agent.isStopped = false;
		if (agent.pathPending)
		{
			return State.Running;
		}

		if (agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
		{
			return State.Failure;
		}
		
		if (agent.remainingDistance <= blackboard.attackRange)
		{
			agent.isStopped = true;
			return State.Success;
		}
		return State.Success;
	}
}
