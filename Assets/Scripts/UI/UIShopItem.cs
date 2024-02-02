using UnityEngine;

namespace CorruptedLandTales
{
    public class UIShopItem : MonoBehaviour
    {
        public event System.Action<StatSO> onClick;
        
        /*private int m_cost;
        private string m_type;
        private int m_level;*/
        private StatSO m_statSo;


        public void SetUpShopItem(StatSO stat)
        {
            m_statSo = stat;
        }
        /*public void SetUpShopItem(string type, int cost, int level)
        {
            m_cost = cost;
            m_type = type;
            m_level = level;
        }*/

        /*public int GetCost()
        {
            return m_cost;
        }

        public string GetType()
        {
            return m_type;
        }*/
        
        public void Click()
        {
            onClick?.Invoke(m_statSo);
        }
    }
}
