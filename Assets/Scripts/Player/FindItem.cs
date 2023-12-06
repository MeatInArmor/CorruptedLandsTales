using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CorruptedLandTales
{
    public class FindItem : MonoBehaviour
    {
        [SerializeField] float m_findRange;
        
        private Collider[] m_result = new Collider[2];
        private LayerMask m_layerMask;

        private void Start()
        {
            m_layerMask = LayerMask.GetMask("Item");
        }
        
        private void FixedUpdate()
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position,  m_findRange, m_result, m_layerMask,
                QueryTriggerInteraction.Ignore);
            
            for (int i = 0; i < count; i++)
            {
                //var item = 
            }
        }
    }
}
