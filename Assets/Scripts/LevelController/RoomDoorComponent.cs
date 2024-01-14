using UnityEngine;

namespace CorruptedLandTales
{
    public class RoomDoorComponent : MonoBehaviour
    {
        private bool m_flag;
        private BoxCollider m_collider;
        private MeshRenderer m_renderer;
        
        public event System.Action onPlayerEnter;
        
        private void Awake()
        {
            m_collider = gameObject.GetComponent<BoxCollider>();
            m_renderer = gameObject.GetComponent<MeshRenderer>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onPlayerEnter?.Invoke();
            }
        }

        public void Activate() 
        {
            m_collider.enabled = true;
            m_renderer.enabled = true;
            m_collider.isTrigger = false;
        }

        public void Deactivate()
        {
            if (!m_flag)
            {
                m_collider.enabled = true;
                m_renderer.enabled = false;
                m_collider.isTrigger = true;
            }
        }

        public void SetDoorFlag(bool type) 
        {
            m_flag = type; // закостылял проверку что дверь от босса
        }
    }
}
