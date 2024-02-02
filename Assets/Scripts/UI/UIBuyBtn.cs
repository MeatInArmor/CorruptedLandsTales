using UnityEngine;
using UnityEngine.UIElements;

namespace CorruptedLandTales
{
    public class UIBuyBtn : MonoBehaviour
    {
        public event System.Action onClickBuyButton;
        public void Click()
        {
            onClickBuyButton?.Invoke();
        }
    }
}
