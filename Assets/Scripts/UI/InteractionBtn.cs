using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class InteractionBtn : MonoBehaviour
    {
        [SerializeField] private ItemFinder m_ItemFinder;
        [SerializeField] private Image m_parentImage;
        [SerializeField] private Image[] m_childImage;

        private void OnEnable() 
        {
            m_ItemFinder.onFindItem += TurnOn;
            m_ItemFinder.onMissItem += TurnOff;
        }
        
        private void OnDisable()
        {
            m_ItemFinder.onFindItem -= TurnOn;
            m_ItemFinder.onMissItem -= TurnOff;
        }

        private void TurnOn(GameObject item)
        {
            m_parentImage.enabled = true;
            foreach (var image in m_childImage)
                image.enabled = true;
        }

        private void TurnOff()
        {
            m_parentImage.enabled = false;
            foreach (var image in m_childImage)
                image.enabled = false;
        }
    }
}
