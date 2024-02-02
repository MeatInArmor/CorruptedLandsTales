namespace CorruptedLandTales
{
    public class MapState : GameState
    {

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
            if (isActiveAndEnabled)
                Exit();
            else 
                Enter();
        }

    }

}
