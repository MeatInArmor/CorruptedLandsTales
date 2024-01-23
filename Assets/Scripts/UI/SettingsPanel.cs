using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Slider m_musicVolume;
        [SerializeField] private Slider m_fxVolume;
        [SerializeField] private TMPro.TMP_Dropdown m_quality;

        public event System.Action<int> onMusicVolumeChanged;
        public event System.Action<int> onFxVolumeChanged;
        public event System.Action<int> onQuallityChanged;
        private void Awake()
        {
            m_quality.ClearOptions();
            m_quality.AddOptions(new List<string>() { "Очень низкая", "Низкая","Средняя","Высокая","Очень высокая", "Ультра"});
        }
        private void Start()
        {
            m_musicVolume.onValueChanged.AddListener(value => onMusicVolumeChanged?.Invoke(Mathf.RoundToInt(value)));
            m_fxVolume.onValueChanged.AddListener(value => onFxVolumeChanged?.Invoke(Mathf.RoundToInt(value)));
            m_quality.onValueChanged.AddListener(index => onQuallityChanged?.Invoke(index));

        }
        public void SetMusic(int volume)
        {
            m_musicVolume.value = volume;
        }
        public void SetFx(int volume)
        {
            m_fxVolume.value = volume;
        }
        public void SetQuallity(int index)
        {
            m_quality.value = index;
        }
    }

}
