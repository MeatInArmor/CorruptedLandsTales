using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class UILevelPanel : MonoBehaviour
    {
        [SerializeField] private List<Image> m_levels;

        public void SetUpLevels(int level)
        {
            for (int i = 0; i < level; i++)
            {
                m_levels[i].gameObject.SetActive(true);
            }
        }

        public void RefreshLevels()
        {
            for (int i = 0; i < m_levels.Count; i++)
            {
                m_levels[i].gameObject.SetActive(false);
            }
        }
    }
}
