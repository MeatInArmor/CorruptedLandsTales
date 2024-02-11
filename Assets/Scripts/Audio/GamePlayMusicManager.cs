using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class GamePlayMusicManager : MonoBehaviour
    {
        [SerializeField] private string[] m_music;
        [SerializeField] private AudioPlayer m_audioPlayer;

        private int m_index;
        private AudioSource m_audioSource;

        private void Start()
        { 
            m_index = Random.Range(0, m_music.Length);
            m_audioSource = m_audioPlayer.audioSource;
            LoopMusic();
        }
        
        private void LoopMusic()
        {
            if (m_index + 1 == m_music.Length)
            {
                m_index = 0;
            }
            else
            {
                m_index += 1;
            }
            m_audioPlayer.PlayAudio(m_music[m_index]);
        }

        private void Update()
        {
            if (m_audioSource.isPlaying == false)
            {
                LoopMusic();
            }
        }
    }
}
