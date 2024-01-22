using UnityEngine;

namespace CorruptedLandTales
{
    public class FindItem : MonoBehaviour
    {
        [SerializeField] float m_findRange = 2.0f;
        [SerializeField] private GameObject m_pickUpbtn;
        [SerializeField] private HealthComponent m_healthComponent;
        
        private Collider[] m_result = new Collider[2];
        private PickUpItem m_upItem;
        private LayerMask m_layerMask;
        private AttackManager m_attackManager;
        private bool m_flag = true;
        
        public event System.Action onFindItem;
        public event System.Action onDisableItem;

        private void Start()
        {
            m_attackManager = GetComponentInParent<AttackManager>();
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
                    m_upItem = m_result[i].GetComponent<PickUpItem>();
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

        public void PickUp()
        {
            onDisableItem?.Invoke();
            if (m_upItem.GetWeaponData()!=null)
            {
                m_attackManager.Initialize(m_upItem.GetWeaponData());
            }
            else
            {
                m_healthComponent.HealHealth(m_upItem.GetHealth());
            }
            //Destroy(gameObject);
        }
    }
}
