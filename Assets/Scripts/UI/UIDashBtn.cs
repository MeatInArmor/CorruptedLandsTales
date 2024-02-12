using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class UIDashBtn : MonoBehaviour
    {
        [SerializeField] private Image m_fillImage;
        [SerializeField] private PlayerCharAnimComponent m_charComponent;
        private float m_cooldown;
        private float m_currentCooldown;

        private void Awake()
        {
            m_cooldown = m_charComponent.dashCooldown;
            m_fillImage.fillAmount = 0f;
            m_currentCooldown = 0;
            m_charComponent.onUseDash += () =>
            {
                m_fillImage.fillAmount = 0f;
                m_currentCooldown = 0;
                StartCoroutine(StartCooldown());
            };
            StartCoroutine(StartCooldown());
        }

        private IEnumerator StartCooldown()
        {
            while (m_fillImage.fillAmount < 1)
            {
                m_currentCooldown += Time.unscaledDeltaTime;
                m_fillImage.fillAmount = m_currentCooldown / m_cooldown;
                yield return null;
            }
        }
    }
}