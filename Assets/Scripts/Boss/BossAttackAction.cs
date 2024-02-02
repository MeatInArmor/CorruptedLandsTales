using CorruptedLandTales;


namespace TheKiwiCoder {
    [System.Serializable]
    public class BossAttackAction : ActionNode
    {
        private BossAttackManager m_attackManager;
        protected override void OnStart()
        {
            if (!m_attackManager)
            {
                m_attackManager = context.gameObject.GetComponent<BossAttackManager>();
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (m_attackManager)
            {
                m_attackManager.BossAnimateAttack(blackboard.typeOfAttack);
            }
            return State.Success;
        }
    }
}
