using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class InteractItemHandler : MonoBehaviour
    {
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private HealthComponent m_healthComponent;
        [SerializeField] private ItemFinder m_itemFinder;
        
        private List<GameObject> m_weapons = new (5);//будет аллокация, нужно переписывать capacity = количеству оружия

        private void OnEnable()
        {
            m_itemFinder.onInteractItem += HandleItem;
        }

        private void OnDisable()
        {
            m_itemFinder.onInteractItem -= HandleItem;
        }

        private void HandleItem()
        {
            var item = m_itemFinder.GetItem();
            var data = item.GetComponent<IInteractiveItem>().GetData();
            if (data != null)
            {
                if (data is InteractiveHealSO healData)
                {
                    m_healthComponent.HealHealth(healData.healAmount);
                }
                if (data is InteractiveChestSO chestData)
                {
                    m_weapons = chestData.weapons;
                    var weapon = m_weapons[Random.Range(0, m_weapons.Count)];
                    Instantiate(weapon, item.transform.position, item.transform.rotation);
                }
                if (data is InteractiveWeaponSO weaponData)
                {
                    m_attackManager.Initialize(weaponData.weapon);
                }
                Destroy(item);
            }
        }
    }
}
