using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AttackManager : MonoBehaviour
    {
        private List<AttackItem> m_items = new();
        private int m_currentIndex = -1;

        private void Start()
        {
            GetComponentsInChildren(true, m_items);

            m_currentIndex =  m_items.Count > 0 ? 0: -1;
        }

        public void Next()
        {
            if (m_items.Count > 0)
            {
                //if (m_items[m_currentIndex].inInventory) доелать под такой флаг, как будто не нужно 
                m_items[m_currentIndex].TurnOff();
                m_currentIndex++;
                if (m_currentIndex >= m_items.Count)
                {
                    m_currentIndex = 0;
                }
                m_items[m_currentIndex].TurnOn();
            }
        }

        public void StartUseWeapon()
        {
            if (m_currentIndex >= 0) 
            { 
                m_items[m_currentIndex].StartUse();
            }
        }

        public void EndUseWeapon()
        {
            m_items[m_currentIndex].EndUse();
        }
    }
}
