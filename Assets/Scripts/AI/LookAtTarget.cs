using TheKiwiCoder;
using UnityEngine;

namespace CorruptedLandTales.AI
{
	public class LookAtTarget : ActionNode
	{
		private LayerMask m_layerMask;
		private Transform m_agentTransform;
		private bool isBoss = false;
		private string name;
		private float m_angularSpeed;
		protected override void OnStart()
		{
			m_layerMask = LayerMask.GetMask("Projectile");
			m_agentTransform = context.agent.transform;
			m_angularSpeed = context.agent ? context.agent.angularSpeed : 360f;
			if (name == null)
			{
				name = context.gameObject.name;
				
				if (name == "Boss")
				{
					isBoss = true;
				}
			}
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			RaycastHit hit;
			Vector3 fwd = m_agentTransform.TransformDirection(Vector3.forward);
			if (Physics.Raycast( m_agentTransform.position,  
				    fwd, out hit, 100, ~m_layerMask))
			{
				if (!isBoss)
				{
					if (!hit.transform.CompareTag("Player"))
					{
						blackboard.attackRange = 0.1f;
						Debug.DrawRay(m_agentTransform.position,
							fwd * 100, Color.white);

					}
					else
					{
						blackboard.attackRange = blackboard.reserveAttackRange;
						Debug.DrawRay(m_agentTransform.position,
							fwd * hit.distance, Color.red);
					}
				}
			}

			var targetPosition = blackboard.target.position;
			var contextTr = context.transform;
			var contextPosition = contextTr.position;
			
			targetPosition.y = contextPosition.y;
			var dir = targetPosition - contextPosition;
			contextTr.rotation = Quaternion.RotateTowards(contextTr.rotation, Quaternion.LookRotation(dir), m_angularSpeed * Time.deltaTime);
			
			return State.Success;
		}
	}
}