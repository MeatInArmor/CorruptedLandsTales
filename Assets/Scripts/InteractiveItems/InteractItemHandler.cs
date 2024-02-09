using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class InteractItemHandler : MonoBehaviour
    {
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private WeaponUpgrader m_weaponUpgrader;
        [SerializeField] private HealthComponent m_healthComponent;
        [SerializeField] private ItemFinder m_itemFinder;
        [SerializeField] private Animator m_animator;
        [SerializeField] private InitCharacter m_initCharacter;
        [SerializeField] private CharacterSO m_data;

        private GameObject m_item;
        private float m_damageToIncrease;
        private List<GameObject> m_weapons = new (5);//будет аллокация если сделать не конечный count
                                                     //нужно переписывать capacity = количеству оружия
                                                     
        private void Awake()
        {
            m_damageToIncrease = m_weaponUpgrader.damageToIncrease;
        }

        private void OnEnable()
        {
            m_itemFinder.onFindItem += GetItem;
        }

        private void OnDisable()
        {
            m_itemFinder.onFindItem -= GetItem;
        }

        private void GetItem(GameObject item)
        {
            m_item = item;
        }
        
        public void UpgradeCurrentWeapon() //TODO лютый костыль, нужно потом переделать в Initialize
        {
            if(m_item != null)
            {
                var weapon = m_attackManager.activeWeapon as MeleeAttack;
                if (weapon != null)
                {
                    weapon.IncreaseDamage(m_damageToIncrease);
                    Destroy(m_item);
                    m_item = null;
                }
            }
        }

        public void HandleItem()
        {
            if(m_item != null)
            {
                var data = m_item.GetComponent<IInteractiveItem>().GetData();              


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
                        Instantiate(weapon, m_item.transform.position, m_item.transform.rotation);
                    }

                    if (data is InteractiveWeaponSO weaponData)
                    {
                        var equipWeaponData = m_attackManager.activeWeaponLayer;
                        var equipWeaponDataSkill = m_attackManager.activeLayerWeaponSkill;
                        // изменили вес анимации для экипированного оружия
                        name = equipWeaponData;                        
                        m_animator.SetLayerWeight(m_animator.GetLayerIndex(name), 0f);
                        name = equipWeaponDataSkill;
                        m_animator.SetLayerWeight(m_animator.GetLayerIndex(name), 0f);

                        m_attackManager.Initialize(weaponData.weapon);

                        // изменили вес анимации для поднятого оружия
                        name = weaponData.weapon.layerAnimName;
                        //m_animator.SetLayerWeight(m_animator.GetLayerIndex(name), 1f);
                        //name = weaponData.weapon.layerAnimNameSpecialWeapon;
                        //m_animator.SetLayerWeight(m_animator.GetLayerIndex(name), 1f);
                    }
                    Destroy(m_item);
                    m_item = null;
                }
            }
        }
    }
}
