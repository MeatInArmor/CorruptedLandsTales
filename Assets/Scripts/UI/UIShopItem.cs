using UnityEngine;

namespace CorruptedLandTales
{
    public class UIShopItem : MonoBehaviour
    {
        public event System.Action<string, int> onClick;
        
        private int m_cost;
        private string m_type;
        private int m_level;

        public void SetUpShopItem(string type, int cost, int level)
        {
            m_cost = cost;
            m_type = type;
            m_level = level;
        }

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
            onClick?.Invoke(m_type, m_cost);
        }
    }
}