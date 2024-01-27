using UnityEngine;

namespace CorruptedLandTales
{
    public class FindItem : MonoBehaviour
    {
        [SerializeField] private float m_findRange = 2.0f;
        [SerializeField] private AttackManager m_attackManager;
        [SerializeField] private HealthComponent m_healthComponent;
        
        private Collider[] m_result = new Collider[2];
        private IInteractiveItem m_useItemComponent;
        private GameObject m_useItem; 
        private LayerMask m_layerMask;
        private bool m_flag = true;
        
        public event System.Action onFindItem;
        public event System.Action onDisableItem;

        private void Start()
        {
            m_layerMask = LayerMask.GetMask("Item");
        }
        
        //TODO можно вынести в отдельный скрипт
        private void Update()
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position,  m_findRange, m_result, m_layerMask,
                QueryTriggerInteraction.Ignore);
            
            if (count > 0)
            {
                onFindItem?.Invoke();
                for (int i = 0; i < count; i++)
                {
                    m_useItemComponent = m_result[i].GetComponent<IInteractiveItem>();
                    m_useItem = m_result[i].gameObject;
                }
                m_flag = true;
            }
            else
            {
                if (m_flag)
                {
                    onDisableItem?.Invoke();
                    m_flag = false;
                }
            }
        }
        
        //TODO переписать как будет правильнее
        public void UseItem()
        {
            if (m_useItemComponent!=null)
            {
                var data = m_useItemComponent.GetData<object>();
                if (data != null)
                {
                    if (data is float)
                    {
                        m_healthComponent.HealHealth((float)data);
                    }

                    if (data is ScriptableObject)
                    {
                        m_attackManager.Initialize((WeaponSO)data);
                    }

                    if (data is GameObject)
                    {
                        Instantiate((GameObject)data, m_useItem.transform.position, m_useItem.transform.rotation);
                    }

                    Destroy(m_useItem);
                }
            }
        }
    }
}
