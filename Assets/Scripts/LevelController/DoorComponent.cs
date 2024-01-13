using UnityEngine;

namespace CorruptedLandTales
{
    public class DoorComponent : MonoBehaviour
    {
        private bool m_isActive;
        private BoxCollider m_collider;
        private MeshRenderer m_renderer;
        private DoorStatus m_state = DoorStatus.Waiting;
        
        public event System.Action onPlayerEnter;

        private enum DoorStatus
        {
            Activated,
            Deactivated,
            Waiting
        }
        private void Awake()
        {
            m_collider = gameObject.GetComponent<BoxCollider>();
            m_renderer = gameObject.GetComponent<MeshRenderer>();
            m_collider.enabled = true;
            m_renderer.enabled = false;
            m_collider.isTrigger = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onPlayerEnter?.Invoke();
            }
        }
        
        private void Update()
        {
            switch (m_state)
            {
                case DoorStatus.Waiting:
                    break;
                
                case DoorStatus.Activated:
                    m_collider.enabled = true;
                    m_renderer.enabled = true;
                    m_collider.isTrigger = false;
                    break;
                
                case DoorStatus.Deactivated:
                    m_collider.enabled = true;
                    m_renderer.enabled = false;
                    m_collider.isTrigger = true;
                    break;
            }
        }

        public void Activate()
        {
            m_state = DoorStatus.Activated;
        }

        public void Deactivate()
        {
            m_state = DoorStatus.Deactivated;
        }
    }
}
