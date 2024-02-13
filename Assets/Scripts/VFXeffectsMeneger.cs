using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class VFXeffectsMeneger : MonoBehaviour
    {
        [SerializeField] ParticleSystem m_HealEffects;
        [SerializeField] ParticleSystem m_PucnhGroundEffect;
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
        public void PucnhGroundEffect()
        {
            m_PucnhGroundEffect.Play(true);
        }
    }
}
