using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class ItemFinder : MonoBehaviour
    {
        [SerializeField] private float m_findRange = 2.0f;
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private HealthComponent m_healthComponent;
        
        private Collider[] m_result = new Collider[2];
        private List<GameObject> m_weapons = new (5); //будет аллокация, нужно переписывать capacity = количеству оружия
        private IInteractiveItem m_interactItemComponent;
        private GameObject m_interactItem;
        private LayerMask m_layerMask;
        private bool m_flag = true;
        
        public event System.Action onFindItem;
        public event System.Action onMissItem;

        private void Start()
        {
            m_layerMask = LayerMask.GetMask("Item");
        }
        
        private void Update()
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position,  m_findRange, m_result, m_layerMask,
                QueryTriggerInteraction.Ignore);
            
            if (count > 0)
            {
                onFindItem?.Invoke();
                for (int i = 0; i < count; i++)
                {
                    m_interactItemComponent = m_result[i].GetComponent<IInteractiveItem>();
                    m_interactItem = m_result[i].gameObject;
                }
                m_flag = true;
            }
            else
            {
                if (m_flag)
                {
                    onMissItem?.Invoke();
                    m_flag = false;
                    for (int i = 0; i < m_result.Length; i++)
                    {
                        m_result[i] = null;
                    }
                }
            }
        }
        
        public void UseItem()
        {
            if (m_interactItemComponent!=null)
            {
                var data = m_interactItemComponent.GetData();
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
                        Instantiate(weapon, m_interactItem.transform.position, m_interactItem.transform.rotation);
                    }
                    if (data is InteractiveWeaponSO weaponData)
                    {
                        m_attackManager.Initialize(weaponData.weapon);
                    }
                    Destroy(m_interactItem);
                }
            }
        }
    }
}
