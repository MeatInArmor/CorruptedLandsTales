using UnityEngine;

namespace CorruptedLandTales
{
    public class ItemFinder : MonoBehaviour
    {
        [SerializeField] private float m_findRange = 2.0f;
        
        private Collider[] m_result = new Collider[2];
        private IInteractiveItem m_interactItemComponent;
        private GameObject m_interactItem;
        private LayerMask m_layerMask;
        private bool m_flag = true;
        
        public event System.Action onFindItem;
        public event System.Action onMissItem;
        public event System.Action onInteractItem;

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
        
        public void InteractItem()
        {
            onInteractItem?.Invoke();
        }

        public GameObject GetItem()
        {
            return m_interactItem;
        }
    }
}
