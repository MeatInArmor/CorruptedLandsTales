using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class BossAttackManager : MonoBehaviour
    {
        [Header("Attack")]
        [SerializeField] private List<WeaponSO> m_weaponList;
        
        private List<IAttackItem> m_attackList = new List<IAttackItem>();
        
        public event System.Action onMeleeAttack1Action;
        public event System.Action onMeleeAttack2Action;
        public event System.Action onMeleeAttack3Action;
        public event System.Action onRangeAttack1Action;
        
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

        public void BossAnimateAttack(string attackType) //при добавлении атаки нужно будет расширять switch
        {                                       
            switch (attackType)
            {
                case "meleeAttack1":
                    onMeleeAttack1Action?.Invoke();
                    break;
                case "rangeAttack1":
                    onRangeAttack1Action?.Invoke();
                    break;
                case "meleeAttack2":
                    onMeleeAttack2Action?.Invoke();
                    break;
                case "meleeAttack3":
                    onMeleeAttack3Action?.Invoke();
                    break;
                default:
                    Debug.Log("incorrect attack type");
                    break;
            }
        }
        
        public void BossAttack(string attackType)
        {                                       
            switch (attackType)
            {
                case "meleeAttack1":
                    m_attackList[0].Use();
                    break;
                case "rangeAttack1":
                    m_attackList[1].Use();
                    break;
                case "meleeAttack2":
                    m_attackList[2].Use();
                    break;
                case "meleeAttack3":
                    m_attackList[3].Use();
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
            return new string[] {"meleeAttack1", "rangeAttack1", "meleeAttack2", "meleeAttack3"};
        }
    }
}
