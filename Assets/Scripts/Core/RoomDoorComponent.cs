using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class RoomDoorComponent : MonoBehaviour
    {
        [SerializeField] private List<AddDoorComponent> m_addDoors;
        private bool m_flag;
        private BoxCollider m_collider;
        private MeshRenderer m_renderer;
        private AddDoorComponent enterAdd;
        private AddDoorComponent exitAdd;
        
        public event System.Action onPlayerEnter;
        
        private void Awake()
        {
            m_collider = GetComponent<BoxCollider>();
            m_renderer = GetComponent<MeshRenderer>();
            foreach (var addDoor in m_addDoors)
            {
                addDoor.onEnter += () =>
                {
                    if (enterAdd == null && addDoor.Flag == false)
                    {
                        enterAdd = addDoor;
                    }
                    else
                    {
                        if (!addDoor.Flag == true)
                        {
                            exitAdd = addDoor;
                            enterAdd.Activate();
                        }
                    }
                };
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (enterAdd != null && exitAdd != null)
                {
                    onPlayerEnter?.Invoke();
                }
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
                if (enterAdd != null && exitAdd != null)
                {
                    enterAdd.Deactivate();
                    exitAdd.Deactivate();
                }
            }
        }

        public void SetDoorFlag(bool type) 
        {
            m_flag = type; // закостылял проверку что дверь от босса
        }
    }
}
