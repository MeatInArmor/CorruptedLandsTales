using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PatrolPoints : MonoBehaviour
    {
        [SerializeField] private List<Vector3> m_points;

        public List<Vector3> GetPoints()
        {
           return m_points;
        }

        public void AddPoints(List<Vector3> list)
        {
            m_points.AddRange(list);
        }
    }
}
