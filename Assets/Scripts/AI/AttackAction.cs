using CorruptedLandTales;


namespace TheKiwiCoder {
    [System.Serializable]
    public class AttackAction : ActionNode
    {
        private AttackManager m_attackManager;
        protected override void OnStart()
        {
            if (!m_attackManager)
            {
                m_attackManager = context.gameObject.GetComponent<AttackManager>();
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (m_attackManager)
            {
                m_attackManager.AnimateUse();
            }
            return State.Success;
        }
    }
}
