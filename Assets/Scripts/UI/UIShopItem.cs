using UnityEngine;
using UnityEngine.UI;


namespace CorruptedLandTales
{
    public class UIShopItem : MonoBehaviour
    {
        public event System.Action<StatSO> onClick;
        private int m_level;
        private StatSO m_statSo;
        [SerializeField] private StatLevels statLevel;

        public void SetUpShopItem(StatSO stat)
        {
            m_statSo = stat;
        }
        
        public void RefreshStatsLevelImagin()
        {
            for(int i = 0; i < 5; i++)
            {
                if(i <= m_statSo.level)
                    statLevel.level[i].color = Color.red;
                else
                    statLevel.level[i].color = Color.white;
            }
        }
        
        public void Click()
        {
            onClick?.Invoke(m_statSo);
        }
    }
}
