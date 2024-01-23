using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class GameInstance : MonoBehaviour
    {
        public static GameInstance instance;
        public PlayerSettings playerSettings { private set; get;  } = new PlayerSettings(); 
        public string startScene = "MainMenu";
        private void Awake()
        {
            if(instance != null) 
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            playerSettings.Load();
            ApplySettings(); 
        }
        public void ApplySettings()
        {
            QualitySettings.SetQualityLevel(playerSettings.settings.quality);
        }
        private void OnApplicationQuit()
        {
            playerSettings.Save();
        }

        [RuntimeInitializeOnLoadMethod]
        static void OnRunTimeInitialized()
        {
            instance = FindAnyObjectByType<GameInstance>();
            if(instance == null )
            {
                var prefab = Resources.Load("GameInstance");
                Instantiate(prefab);
            }
        }
    }
}
