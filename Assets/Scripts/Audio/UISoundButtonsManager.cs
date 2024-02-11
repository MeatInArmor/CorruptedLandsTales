using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedLandTales
{
    public class UISoundButtonsManager : MonoBehaviour
    {
        [SerializeField] private List<Button> m_buttons;
        [SerializeField] private AudioPlayer m_audioPlayer;
        [SerializeField] private string m_buttonSound;

        private void Start()
        {
            foreach (var button in m_buttons)
            {
                button.onClick.AddListener(PlayUISfx);
            }
        }

        private void PlayUISfx()
        {
            m_audioPlayer.PlayAudio(m_buttonSound);
        }
    }
}
