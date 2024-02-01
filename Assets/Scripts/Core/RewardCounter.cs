using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class RewardCounter : MonoBehaviour
    {
        [SerializeField] private GameController m_gameController;
        [SerializeField] private LevelController m_levelController;

        private List<RoomComponent> m_rooms = new List<RoomComponent>(10);
        private int m_enemyCount = 0;
        
        private void Start()
        {
            m_rooms = m_levelController.rooms;
            SubscribeEnemies(m_rooms);
            m_gameController.onLevelCleared += OnNextLevel;
        }

        private void OnNextLevel()
        {
            m_levelController = m_gameController.activeLevelController;
            m_rooms = m_levelController.rooms;
            SubscribeEnemies(m_rooms);
        }
        
        private void OnDisable()
        {
            m_gameController.onLevelCleared -= OnNextLevel;
        }
        
        private void SubscribeEnemies(List<RoomComponent> rooms)
        {
            foreach (var room in m_rooms)
            {
                var enemies = room.enemies;
                if (enemies!=null)
                {
                    foreach (var enemy in enemies)
                    {
                        if (enemy.TryGetComponent<HealthComponent>(out HealthComponent healthComponent))
                        {
                            healthComponent.onDie += () => { m_enemyCount += 1; };
                        }
                    }
                }
            }
        }
        
        public int CountReward()
        {
            return (int)(m_enemyCount/2 + Time.time/60 + m_gameController.levelCount * 5);
        }
    }
}
