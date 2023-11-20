using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CorruptedLandTales
{
    public class Enemy : MonoBehaviour
    {
        private NavMeshAgent m_agent;

        private void Awake()
        {
            m_agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            RandomPoint();
        }

        private void RandomPoint()
        {
            Vector3 target = Random.insideUnitSphere;
            m_agent.SetDestination(target);
        }

        private void Update()
        {
            if (m_agent.remainingDistance <= m_agent.stoppingDistance) 
            {
                RandomPoint();
            }
        }
    }
}
