using ShadowChimera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class MapState : GameState
    {
        
        public MapState miniMap;


        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        public void OpenCloseMap()
        {
            if (miniMap.isActiveAndEnabled)
                miniMap.Exit();
            else 
                miniMap.Enter();
        }

    }

}
