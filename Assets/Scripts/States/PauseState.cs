using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace CorruptedLandTales
{
    public class PauseState : GameState
    {
        [SerializeField] private GameOverState m_gameOverState;
        
        public GameplayState gameplayState;
        public MapState mapState;
        public Text killsCount;
        public Text levelsCleared;


        protected override void OnEnable()
        {
            base.OnEnable();
            Time.timeScale = 0;
            killsCount.text = NumbersCounts.kills.ToString();
            levelsCleared.text = NumbersCounts.levelsCleared.ToString();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            Time.timeScale = 1;
        }
        
        public void Concede()
        {
            Exit();
            m_gameOverState.Enter();
            
        }
        public void Resume()
        {
            Exit();
            gameplayState.Enter();
            mapState.Enter();

        }
        public void MenuExit()
        {
            SceneManager.LoadScene("MainMenu");
            NumbersCounts.kills = 0;
            NumbersCounts.levelsCleared = 0;

        }
    }
}
