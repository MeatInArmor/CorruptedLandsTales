using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class FindItem : MonoBehaviour
    {
        [SerializeField] float m_findRange = 2.0f;
        [SerializeField] private GameObject m_pickUpbtn;
        
        private Collider[] m_result = new Collider[2];
        private PickUpItem m_upItem;
        private LayerMask m_layerMask;
        private bool m_isActive;
        private AttackManager m_attackManager;

        private void Start()
        {
            m_attackManager = GetComponentInParent<AttackManager>();
            m_layerMask = LayerMask.GetMask("Item");
            m_isActive = false;
        }

        private void Update()
        {
            if (m_isActive)
            {
                m_pickUpbtn.SetActive(true);
            }
            else
            {
                m_pickUpbtn.SetActive(false);
            }
        }

        private void FixedUpdate() // пока через сферу будет
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position,  m_findRange, m_result, m_layerMask,
                QueryTriggerInteraction.Ignore);
            
            if (count > 0)
            {
                m_isActive = true;
                for (int i = 0; i < count; i++)
                {
                    m_upItem = m_result[i].GetComponent<PickUpItem>();
                }
            }
            else
            {
                m_isActive = false;
            }
        }

        public void PickUp()
        {
            m_attackManager.Initialize(m_upItem.GetWeaponData());
            //Destroy(gameObject);
        }
    }
}
