using TMPro;
using UnityEngine;

namespace CorruptedLandTales
{
    public class UIPlayerInfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_moneyText;

        private void Start()
        {
            Refresh(GameInstance.instance.playerSettings.money);
        }

        private void OnEnable()
        {
            GameInstance.instance.playerSettings.changeMoney += Refresh;
        }

        private void OnDisable()
        {
            GameInstance.instance.playerSettings.changeMoney -= Refresh;
        }

        private void Refresh(int money)
        {
            m_moneyText.text = money.ToString();
        }
    }
}
