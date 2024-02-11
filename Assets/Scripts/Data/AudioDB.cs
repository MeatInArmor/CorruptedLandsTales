using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "AudioDB", menuName = "CorruptedLandTales/AudioDB")]
    public class AudioDB : ScriptableObject
    {
        [SerializeField] private List<AudioData> audios;

        public AudioClip GetAudio(string id)
        {
            return audios.Find(audio => audio.id == id).clip;
        }
    }
    
    [System.Serializable]
    public class AudioData
    {
        public string id;
        public AudioClip clip;
    }
}
