using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class RandomPositions : MonoBehaviour
    {
        [SerializeField] private GameObject startCoordinate;
        [SerializeField] private GameObject endCoordinate;
        [SerializeField] private int partitionCount;
        
        private List<Vector3> m_points = new List<Vector3>();
        private void Awake()
        {
            Vector3 start = startCoordinate.transform.position;
            Vector3 end = endCoordinate.transform.position;
            m_points = BuildCoordinateGrid(start, end, partitionCount);
        }
        
        private List<Vector3> BuildCoordinateGrid(Vector3 startCoordinate, Vector3 endCoordinate, int partitionCount)
        {
            List<Vector3> coordinateGrid = new List<Vector3>();

            
            float stepX = (endCoordinate.x - startCoordinate.x) / partitionCount;
            float stepZ = (endCoordinate.z - startCoordinate.z) / partitionCount;

            
            for (int i = 0; i <= partitionCount; i++)
            {
                for (int j = 0; j <= partitionCount; j++)
                {
                    float x = startCoordinate.x + i * stepX;
                    float z = startCoordinate.z + j * stepZ;

                    
                    float y = 1.0f;

                    Vector3 coordinate = new Vector3(x, y, z);
                    coordinateGrid.Add(coordinate);
                }
            }

            return coordinateGrid;
        }
        
        private void OnDrawGizmos()
        {
            if (m_points!=null)
            {
                for (int i = 0; i < m_points.Count; i += 1)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(new Vector3(m_points[i].x, m_points[i].y, m_points[i].z), new Vector3(1, 1, 1));
                }
            }
        }

        public List<Vector3> GetRandomRoomPoints() 
        {
            var newShuffledList = new List<Vector3>();
            var list = m_points;
            for (int i = 0; i < m_points.Count; i++)
            {
                var randomElementInList = Random.Range(0, list.Count);
                newShuffledList.Add(list[randomElementInList]);
                list.Remove(list[randomElementInList]);
            }
            return newShuffledList;
        }
    }
}
