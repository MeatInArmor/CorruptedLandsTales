using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject m_player;
        [SerializeField] private GameObject m_firstLevel;
        [SerializeField] private GameObject m_levelPrefab;
        [SerializeField] private List<ExitDoorComponent> m_exitDoors;
        
        private GameObject m_activeLevel;
        private int m_levelCount = 1;

        public int levelCount => m_levelCount;

        public event System.Action onLevelCleared;
        public LevelController activeLevelController => m_activeLevel.GetComponentInChildren<LevelController>();
        
        private void Awake()
        {
            m_activeLevel = m_firstLevel;
            SubscribeDoors();
        }

        private void OnPlayerExitLocation()
        {
            Destroy(m_activeLevel);
            RespawnLevel();
            var lc = activeLevelController;
            lc.SetPlayer(m_player);
            UnsubscribeDoors();
            SubscribeDoors();
        }

        private void RespawnLevel()
        {
            Transform activeLevelPos = m_activeLevel.transform;
            m_activeLevel = null;
            m_activeLevel = Instantiate(m_levelPrefab, activeLevelPos.position + new Vector3(0f,50f,0f),
                activeLevelPos.rotation);
        }

        private void SubscribeDoors()
        {
            m_activeLevel.GetComponentsInChildren(true, m_exitDoors);
            foreach (var door in m_exitDoors)
            {
                door.onPlayerExitLocation += OnPlayerExitLocation;
            } 
            onLevelCleared?.Invoke();
        }

        private void UnsubscribeDoors()
        {
            foreach (var door in m_exitDoors)
            {
                door.onPlayerExitLocation -= OnPlayerExitLocation;
            }
            m_exitDoors.Clear();
        }
    }
}
