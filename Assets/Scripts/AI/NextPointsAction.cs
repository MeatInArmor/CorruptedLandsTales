using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace CorruptedLandTales
{
    public class NextPointsAction : ActionNode
    {
        private List<Vector3> m_points = new();
        private RandomSpawn randomSpawn;
        private int m_index = 0;
        protected override void OnStart()
        {
            /*var pointsContainer = context.gameObject.GetComponent<PatrolPoints>();
            if (pointsContainer == null)
            {
                Debug.Log("pointsContainer are null");
                return;
            }
            m_points = pointsContainer.GetPoints();*/
            if (m_points.Count == 0)
            {
                var pointsContainer = context.gameObject.GetComponent<RandomSpawn>();
                if (pointsContainer == null)
                {
                    Debug.LogError("PointsContainer not found!");
                    return;
                }
                m_points = pointsContainer.GetRandomPositions();
            }
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (m_points.Count == 0)
            {
                return State.Failure;
            }

            if (m_index >= m_points.Count - 1)
            {
                m_index = 0;
            }
            else
            {
                m_index++;
            }

            blackboard.moveToPosition = m_points[m_index];
            return State.Success;
        }
    }
}
