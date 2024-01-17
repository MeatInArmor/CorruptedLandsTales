using TheKiwiCoder;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptedLandTales
{
    public class AnimEventCatcher : MonoBehaviour
    {
        private AttackManager m_attackManager;
        [SerializeField] private SpecialAttack m_specialAttack;
        [SerializeField] private CharMoveComponent m_charMoveComponent;
        [SerializeField] private UnityEvent m_EndDie;
        [SerializeField] private UnityEvent m_onImpact;
        private BehaviourTreeRunner m_behaviourTree;

        private void Start()
        {
            m_attackManager = GetComponentInParent<AttackManager>();
            m_behaviourTree = GetComponentInParent<BehaviourTreeRunner>();
        }

        public void Attack()
        {
            m_attackManager.UseWeapon();
        }

        public void SpecialAttack()
        {
            m_specialAttack.CastSpecialAttack();
        }
        
        public void OnEndDie()
        {
            m_EndDie.Invoke();
        }
        
        public void OnImpact()
        {
            m_onImpact.Invoke();
        }

        public void OnEndImpact()
        {
            m_behaviourTree.enabled = true;
        }
        
        public void StartDash()
        {
            m_charMoveComponent.isDashing = true;
        }

        public void EndDash()
        {
            m_charMoveComponent.isDashing = false;
        }
    }
}
