using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SettingsState : GameState
    {
        public MainMenuState mainMenuState;
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        public void CloseSettings()
        {
            mainMenuState.Enter();
            Exit();
        }
    }
}
