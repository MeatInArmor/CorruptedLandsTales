using System;
using UnityEngine;

namespace CorruptedLandTales
{
    public class TimeController : MonoBehaviour
    {
        private int m_currentLevel = 0;
        private int m_newCount = 0;
        
        private void Update()
        {
            if (Time.time % 60 == 0)
            {
                m_currentLevel += 1;
            }
            if (Time.time % 300 == 0)
            {
                m_newCount += 1;
            }
        }

        public int GetMobLevel()
        {
            return m_currentLevel;
        }

        public int GetNewCount()
        {
            return m_newCount;
        }
    }
}
