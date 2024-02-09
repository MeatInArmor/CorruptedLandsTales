using UnityEngine;

namespace CorruptedLandTales
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioDB m_audioDB;
        
        public static SoundManager instance;

        private void Awake()
        {
            if(instance != null) 
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public AudioClip GetAudioById(string id)
        {
            return m_audioDB.GetAudio(id);
        }
        
        [RuntimeInitializeOnLoadMethod]
        static void OnRunTimeInitialized()
        {
            var instance = FindAnyObjectByType<SoundManager>();
            if (instance == null)
            {
                var prefab = Resources.Load<SoundManager>("SoundManager");
                var go = Instantiate(prefab);
                go.name = go.name.Replace("(Clone)", string.Empty);
            }
        }
    }
}
