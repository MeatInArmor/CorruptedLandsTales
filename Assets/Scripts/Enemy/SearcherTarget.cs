using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SearcherTarget : MonoBehaviour
    {
        [SerializeField] private float m_radius;
        [SerializeField] private LayerMask m_layerMask;
        private Collider[] m_result = new Collider[4];

        public float radius => m_radius;

        public Transform FindTarget()
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position, m_radius, m_result, m_layerMask, QueryTriggerInteraction.Ignore);

            if(count > 0)
            {
                return m_result[0].transform;
            }

            return null;
        }
    }
}
