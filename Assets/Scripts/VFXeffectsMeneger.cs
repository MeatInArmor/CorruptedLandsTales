using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class VFXeffectsMeneger : MonoBehaviour
    {
        [SerializeField] ParticleSystem m_HealEffects;
        [SerializeField] ParticleSystem m_PucnhGroundEffect;
        [SerializeField] ParticleSystem m_SwordSpecialEffect;
        [SerializeField] ParticleSystem m_AxeThrowlEffect;
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
        public void SwordSpecialEffect()
        {
            m_SwordSpecialEffect.Play(true);
        }
        public void AxeThrowlEffect()
        {
            m_AxeThrowlEffect.Play(true);
        }
    }
}
