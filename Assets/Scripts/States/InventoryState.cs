namespace CorruptedLandTales
{
    public class InventoryState : GameState
    {
        public GameplayState gameplayState;

        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        public void Close()
        {
            if (this.isActiveAndEnabled)
            {
                Exit();
                gameplayState.Enter();
            }
        }
       
    }
}
