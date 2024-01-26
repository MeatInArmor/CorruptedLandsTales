using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class UsableChest : MonoBehaviour, IUsableItem
    {
        //TODO надо ли чтобы в Chest'e сразу спавнилось оружие или спавнить его в FindItem?
        //с точки зрения производительности лучше сразу заспавнить, с точки зрения правильности в FindItem'e
        [SerializeField] private ChestSO m_chestTier;
        
        private List<GameObject> m_weapons;
        private int m_index;
        //private Vector3 offset = new(0,1,0);

        private void Awake()
        {
            m_weapons = m_chestTier.weapons;
            m_index = Random.Range(0, m_weapons.Count);
            /*var chest = gameObject.transform;
            Instantiate(m_weapons[m_index], chest.position - offset, chest.rotation, chest);*/
        }

        public T GetData<T>()
        {
            //return (T)(object)null;
            return (T)(object)m_weapons[m_index];
        }
    }
}
