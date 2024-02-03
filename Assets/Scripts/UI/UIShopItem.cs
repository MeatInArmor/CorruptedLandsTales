using UnityEngine;

namespace CorruptedLandTales
{
    public class UIShopItem : MonoBehaviour
    {
        public event System.Action<StatSO> onClick;
        private int m_level;
        private StatSO m_statSo;


        public void SetUpShopItem(StatSO stat)
        {
            m_statSo = stat;
        }
        

        
        public void Click()
        {
            onClick?.Invoke(m_statSo);
        }
    }
}
