using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;
using UnityEngine.AI;

namespace CorruptedLandTales
{
    public class NavMeshAgentComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private NavMeshAgent m_agent;

        public void Init(float speed, float sprintSpeed)
        {
            m_agent.speed = speed;
        }
    }
}
