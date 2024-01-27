using System;
using UnityEngine;

namespace CorruptedLandTales
{
    public class StatIncreaser : MonoBehaviour
    {
        [SerializeField] private TimeController m_timeController;
        [SerializeField] private CharacterSO m_meleeData;
        [SerializeField] private CharacterSO m_meleePreset;
        [SerializeField] private CharacterSO m_rangeData;
        [SerializeField] private CharacterSO m_rangePreset;
        [SerializeField] private GameController m_gameController;
        
        private void Awake()
        {
            m_meleeData.RefreshStats(m_meleePreset);
            m_rangeData.RefreshStats(m_rangePreset);
        }

        private void Start()
        {
            m_gameController.onLevelCleared += IncreaseStats;
        }
        
        private void OnDisable()
        {
            m_gameController.onLevelCleared -= IncreaseStats;
        }
        
        private void IncreaseStats()
        {
            for (int i = 0; i <= m_timeController.GetLevel(); i++) 
            {
                    m_meleeData.IncreaseStats();
                    m_rangeData.IncreaseStats();
            }
        }
    }
}
