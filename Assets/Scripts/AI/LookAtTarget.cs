using TheKiwiCoder;
using UnityEngine;

namespace CorruptedLandTales.AI
{
	public class LookAtTarget : ActionNode
	{
		private LayerMask m_layerMask;
		private Transform m_agentTransform;
		protected override void OnStart()
		{
			m_layerMask = LayerMask.GetMask("Projectile");
			m_agentTransform = context.agent.transform;
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			RaycastHit hit;
			Vector3 fwd = m_agentTransform.TransformDirection(Vector3.forward);
			if (Physics.Raycast( m_agentTransform.position,  
				    m_agentTransform.TransformDirection(Vector3.forward), out hit, 100, ~m_layerMask))
			{
				if (!hit.transform.CompareTag("Player"))
				{
					blackboard.attackRange = 0.1f;
					Debug.DrawRay(m_agentTransform.position, 
						m_agentTransform.TransformDirection(Vector3.forward) * 100, Color.white);
					//Debug.Log("Did not Hit");
					
				}
				else
				{
					blackboard.attackRange = blackboard.reserveAttackRange;
					Debug.DrawRay(m_agentTransform.position, 
						m_agentTransform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
					//Debug.Log("Did Hit");
				}
			}
			
			//плавный поворот доделать
			var targetPosition = blackboard.target.position;
			targetPosition.y = context.transform.position.y;
			context.transform.LookAt(targetPosition, Vector3.up);
			return State.Success;
		}
	}
}