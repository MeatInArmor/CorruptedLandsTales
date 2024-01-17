using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class StaticElementsViewState : GameState
    {
        public InventoryState inventoryState;
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        public void OpenColseInventory()
        {
            if (inventoryState.isActiveAndEnabled)
                inventoryState.Exit();
            else
                inventoryState.Enter();
        }
    }
}
