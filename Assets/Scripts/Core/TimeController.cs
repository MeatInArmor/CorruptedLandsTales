using UnityEngine;

namespace CorruptedLandTales
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private float m_intervalUpgradeMobs = 90f;
        [SerializeField] private float m_intervalIncreaseCount = 180f;
        
        private float m_timerUpgradeMobs;
        private float m_timerIncreaseCount;
        private int m_currentLevel = 0;
        private int m_newCount = 0;
        
        private void Update()
        {
            m_timerUpgradeMobs += Time.deltaTime;
            m_timerIncreaseCount += Time.deltaTime;
            if (m_timerUpgradeMobs >= m_intervalUpgradeMobs)
            {
                m_currentLevel += 1;
                m_timerUpgradeMobs -= m_intervalUpgradeMobs;
            }
            if  (m_timerIncreaseCount > m_intervalIncreaseCount)
            {
                m_newCount += 1;
                m_timerIncreaseCount -= m_intervalIncreaseCount;
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
