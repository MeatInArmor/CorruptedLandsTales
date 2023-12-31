using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class MeshSpawn : MonoBehaviour
    {
        [SerializeField] private Transform a;
        [SerializeField] private Transform b;
        [SerializeField] private int m_countQuads = 9; //количество разбиения прямоугольников
        
        private Vector2[] m_pointsCoord; //массив координат для нахождения точек
        private List<Vector2> m_midPointsCoord; //координаты середин прямоугольников
        
        private Vector2 m_aCoord; //координаты точки А
        private Vector2 m_bCoord; //координаты точки B
        
        private float m_stepX; //шаг по x
        private float m_stepZ; //шаг по z

        public int countQuads => m_countQuads;
        private void Awake()
        {
            int countPointsCoord = (int)Mathf.Pow(Mathf.Sqrt(m_countQuads) + 1, 2);
            m_pointsCoord = new Vector2[countPointsCoord];
            m_midPointsCoord = new List<Vector2>(m_countQuads);
            int k = 0;
            float divisor = Mathf.Sqrt(m_countQuads);
            m_aCoord = new Vector2(a.position.x, a.position.z); 
            m_bCoord = new Vector2(b.position.x, b.position.z);
            m_stepX = Mathf.Abs(m_bCoord.x - m_aCoord.x) / divisor;
            m_stepZ = Mathf.Abs(m_bCoord.y - m_aCoord.y) / divisor;
            for (float i = m_aCoord.y; i <= m_bCoord.y; i += m_stepZ)
            {
                for (float j = m_aCoord.x; j <= m_bCoord.x; j += m_stepX)
                {
                    var point = new Vector2(j, i);
                    m_pointsCoord[k] = point;
                    k++;
                }
            }

            int flag = (int) Mathf.Sqrt(m_countQuads) + 1;
            int skipCoordFlag = flag + 1;
            
            for (int i = 0; i < countPointsCoord - 4; i++)
            {
                if ((i + 1) % flag != 0)
                {
                    Vector2 midPointVec = new Vector2((m_pointsCoord[i].x + m_pointsCoord[i + skipCoordFlag].x) / 2,
                        (m_pointsCoord[i].y + m_pointsCoord[i + skipCoordFlag].y) / 2);
                    m_midPointsCoord.Add(midPointVec);
                }
                else
                {
                    
                }
            }
            
            
        }
        
        private void OnDrawGizmos()
        {
            if (m_midPointsCoord!=null)
            {
                for (int i = 0; i < m_midPointsCoord.Count; i += 1)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(new Vector3(m_midPointsCoord[i].x, 1, m_midPointsCoord[i].y), new Vector3(1, 1, 1));
                }
            }
        }

        public List<Vector3> GetRandomRoomPoints() 
        {
            var list = new List<Vector3>();
            
            for (int i = 0; i < m_midPointsCoord.Count; i += 1)
            {
                list.Add(new Vector3(m_midPointsCoord[i].x, 1, m_midPointsCoord[i].y));
            }
            return ShuffleIntList(list);
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
