using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class VFXeffectsMeneger : MonoBehaviour
    {
        [SerializeField] ParticleSystem m_HealEffects;
        void Start()
        {
            //m_HealEffects.Stop(true);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void HeallingEffects()
        {
            m_HealEffects.Play(true);            
        }
    }
}
