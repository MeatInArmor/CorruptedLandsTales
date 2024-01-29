using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class InteractiveHeal : MonoBehaviour, IInteractiveItem
    {
        [SerializeField] private InteractiveHealSO m_healData;
        
        public InteractiveItemSO GetData()
        {
            return m_healData;
        }
    }
}
