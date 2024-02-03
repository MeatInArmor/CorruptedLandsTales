using TheKiwiCoder;

namespace CorruptedLandTales
{
    public class FindTargetAction : ActionNode
    {
        private SearcherTarget m_searcherTarget;
        protected override void OnStart()
        {
            if (!m_searcherTarget)
            {
                m_searcherTarget = context.gameObject.GetComponent<SearcherTarget>();
            }
        }

        protected override void OnStop()
        {	
        }

        protected override State OnUpdate()
        {
            blackboard.target = m_searcherTarget.FindTarget();
            if (blackboard.target)
            {
                blackboard.moveToPosition = blackboard.target.position;
                return State.Success;
            }
            
            return State.Failure;
        }
    }
}