using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class RandomSpawn : MonoBehaviour
    {
        [SerializeField] private Transform a;
        [SerializeField] private Transform b;
        [SerializeField] private float m_step = 0.1f;
        [SerializeField] private int m_countQuads = 2;
        
        private Vector2 m_aCoord;
        private Vector2 m_bCoord;
        private Vector2[][] m_matrixCoord;
        private void Start()
        {
            m_aCoord = new Vector2(a.position.x, a.position.z); 
            m_bCoord = new Vector2(b.position.x, b.position.z); 
            /*float M = Math.Abs(m_aCoord.y - m_bCoord.y); 
            float N = Math.Abs(m_aCoord.x - m_bCoord.x);*/

            for (float i = m_aCoord.x; i <= m_bCoord.x; i += m_step)
            {
                for (float j = m_aCoord.y; j <= m_bCoord.y; j += m_step)
                {
                    
                }
            }
        }
    }
}
