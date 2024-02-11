using UnityEngine;

namespace CorruptedLandTales
{
    public class UIRefreshBtn : MonoBehaviour
    {
        public event System.Action onClickRefreshButton;
        public void Click()
        {
            onClickRefreshButton?.Invoke();
        }
    }
}
