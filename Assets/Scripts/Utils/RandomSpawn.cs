using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace CorruptedLandTales
{
    public class RandomSpawn : MonoBehaviour
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
        private void Start()
        {
            int countPointsCoord = (int)Math.Pow(Math.Sqrt(m_countQuads) + 1, 2);
            m_pointsCoord = new Vector2[countPointsCoord];
            m_midPointsCoord = new List<Vector2>(m_countQuads);
            int k = 0;
            float divisor = (float) Math.Sqrt(m_countQuads);
            m_aCoord = new Vector2(a.position.x, a.position.z); 
            m_bCoord = new Vector2(b.position.x, b.position.z);
            m_stepX = Math.Abs(m_bCoord.x - m_aCoord.x) / divisor;
            m_stepZ = Math.Abs(m_bCoord.y - m_aCoord.y) / divisor;
            
            for (float i = m_aCoord.y; i <= m_bCoord.y; i += m_stepZ)
            {
                for (float j = m_aCoord.x; j <= m_bCoord.x; j += m_stepX)
                {
                    var point = new Vector2(j, i);
                    m_pointsCoord[k] = point;
                    k++;
                }
            }
            
            /*for (int i = 0; i < m_pointsCoord.Length; i += 1)
            {
                Debug.Log($"{m_pointsCoord[i]}");
            }*/

            int flag = (int) Math.Sqrt(m_countQuads) + 1;//flag который определяет крайнюю точку которую нам не нужно брать 
            
            for (int i = 0; i < countPointsCoord - 4; i++)
            {
                if ((i + 1) % flag != 0)
                {
                    Vector2 midPointVec = new Vector2((m_pointsCoord[i].x + m_pointsCoord[i + 5].x) / 2,
                        (m_pointsCoord[i].y + m_pointsCoord[i + 5].y) / 2);
                    m_midPointsCoord.Add(midPointVec);
                }
                else
                {
                    
                }
            }
            
            /*for (int i = 0; i < m_midPointsCoord.Count; i += 1)
            {
                Debug.Log($"{m_midPointsCoord[i]}");
            }*/
        }

        public List<Vector3> GetRandomPositions()
        {
            Random rnd = new Random();
            List<Vector3> m_List = new List<Vector3>(m_midPointsCoord.Count);
            int i = rnd.Next(0, m_midPointsCoord.Count);
            m_List.Add(new Vector3(m_midPointsCoord[i].x, 1.0f,m_midPointsCoord[i].y));
            int j;
            do
            {
                j = rnd.Next(0, m_midPointsCoord.Count);
            } while (j == i);
            m_List.Add(new Vector3(m_midPointsCoord[j].x, 1.0f, m_midPointsCoord[j].y));
            return m_List;
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
    }
}
