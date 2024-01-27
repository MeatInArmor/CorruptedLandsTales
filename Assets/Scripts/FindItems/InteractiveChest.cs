using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class InteractiveChest : MonoBehaviour, IInteractiveItem
    {
        //TODO надо ли чтобы в Chest'e сразу спавнилось оружие или спавнить его в FindItem?
        [SerializeField] private ChestSO m_chestTier;
        
        private List<GameObject> m_weapons;
        private int m_index;

        private void Awake()
        {
            m_weapons = m_chestTier.weapons;
            m_index = Random.Range(0, m_weapons.Count);
        }

        public T GetData<T>()
        {
            return (T)(object)m_weapons[m_index];
        }
    }
}
