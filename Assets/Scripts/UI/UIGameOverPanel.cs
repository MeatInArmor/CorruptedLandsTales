using TMPro;
using UnityEngine;

namespace ShadowChimera
{
    public class UIGameOverPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_rewardText;

        public void SetPlayerReward(int reward)
        {
            m_rewardText.text = reward.ToString();
        }
    }
}
