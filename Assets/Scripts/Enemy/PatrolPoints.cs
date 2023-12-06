using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PatrolPoints : MonoBehaviour
    {
        private List<Vector3> m_points = new List<Vector3>();

        public List<Vector3> GetPoints()
        {
           return m_points;
        }

        public void AddPoints(List<Vector3> list)
        {
            m_points.AddRange(ShuffleIntList(list));
        }
        
        private List<Vector3> ShuffleIntList(List<Vector3> list)
        {
            var newShuffledList = new List<Vector3>();
            var listcCount = list.Count;
            for (int i = 0; i < listcCount; i++)
            {
                var randomElementInList = Random.Range(0, list.Count);
                newShuffledList.Add(list[randomElementInList]);
                list.Remove(list[randomElementInList]);
            }
            return newShuffledList;
        }
    }
}
