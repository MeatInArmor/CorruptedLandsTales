using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class BossAttackManager : MonoBehaviour
    {
        [Header("Attack")]
        [SerializeField] private List<WeaponSO> m_weaponList;
        
        private List<IAttackItem> m_attackList = new List<IAttackItem>();
        private void Start()
        {
            for (int i = 0; i < m_weaponList.Count; i++)
            {
                m_attackList.Add(EquipWeapon(m_weaponList[i]));
            }
        }

        private IAttackItem EquipWeapon<T>(T data) where T: WeaponSO
        {
            var weaponData = data;
            var item = Instantiate(weaponData.prefab, transform);
            var attackComponent = item.GetComponent<IAttackItem>();
            attackComponent.Initialize(weaponData);
            return attackComponent;
        }

        public void BossAttack(string attackType)//при добавлении атаки нужно будет расширять switch
        {                                       
            switch (attackType)
            {
                case "meleeAttack1":
                    m_attackList[0].Use();
                    Debug.Log("meleeAttack1");
                    break;
                case "rangeAttack1":
                    m_attackList[1].Use();
                    Debug.Log("rangeAttack1");
                    break;
                default:
                    Debug.Log("incorrect attack type");
                    break;
            }
        }

        public string[] GetAttackTypes()
        { 
            if (m_weaponList == null)
            {
                return null;
            }
            return new string[] {"meleeAttack1", "rangeAttack1"};
        }
    }
}
