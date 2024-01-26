using System;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class InteractionBtn : MonoBehaviour
    {
        [SerializeField] private FindItem m_findItem;
        [SerializeField] private Image m_parentImage;
        [SerializeField] private Image m_childImage;

        private void OnEnable()
        {
            m_findItem.onFindItem += TurnOn;
            m_findItem.onDisableItem += TurnOff;
        }
        
        private void OnDisable()
        {
            m_findItem.onFindItem -= TurnOn;
            m_findItem.onDisableItem -= TurnOff;
        }

        private void TurnOn()
        {
            m_parentImage.enabled = true;
            m_childImage.enabled = true;
        }

        private void TurnOff()
        {
            m_parentImage.enabled = false;
            m_childImage.enabled = false;
        }
    }
}
