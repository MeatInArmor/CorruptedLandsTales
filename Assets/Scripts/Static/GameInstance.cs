using UnityEngine;
using UnityEngine.Audio;

namespace CorruptedLandTales
{
    public class GameInstance : MonoBehaviour
    {
        public static GameInstance instance;
        [SerializeField] private AudioMixer m_audioMixer;
        public PlayerSettings playerSettings { private set; get;  } = new PlayerSettings(); 
        public string startScene = "MainMenu";
        private void Awake()
        {
            if(instance != null) 
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            playerSettings.Load();
            ApplySettings(); 
        }
        public void ApplySettings()
        {
            QualitySettings.SetQualityLevel(playerSettings.settings.quality);
            m_audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80f, 0f, playerSettings.settings.musicVolume / 100f));
            m_audioMixer.SetFloat("SfxVolume", Mathf.Lerp(-80f, 0f, playerSettings.settings.fxVolume / 100f));
        }
        private void OnApplicationQuit()
        {
            playerSettings.Save();
        }

        [RuntimeInitializeOnLoadMethod]
        static void OnRunTimeInitialized()
        {
            var instance = FindAnyObjectByType<GameInstance>();
            if (instance == null)
            {
                var prefab = Resources.Load<GameInstance>("GameInstance");
                var go = Instantiate(prefab);
                go.name = go.name.Replace("(Clone)", string.Empty);
            }
        }
    }
}
