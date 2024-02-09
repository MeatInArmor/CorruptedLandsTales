using System;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource m_audioSource;
        
        private SoundManager m_soundManager;
        private AudioClip m_clip;

        public AudioSource audioSource => m_audioSource;
        
        private void Start()
        {
            m_soundManager = SoundManager.instance;
        }

        public void PlayAudio(string id)
        {
            m_clip = m_soundManager.GetAudioById(id);
            m_audioSource.PlayOneShot(m_clip);
        }
    }
}
