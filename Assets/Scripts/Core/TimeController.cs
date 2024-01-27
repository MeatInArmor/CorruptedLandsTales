using System;
using UnityEngine;

namespace CorruptedLandTales
{
    public class TimeController : MonoBehaviour
    {
        private int m_currentLevel = 0;
        
        private void Update()
        {
            if (Time.time % 60 == 0)
            {
                m_currentLevel += 1;
            }
        }

        public int GetLevel()
        {
            return m_currentLevel;
        }
    }
}
