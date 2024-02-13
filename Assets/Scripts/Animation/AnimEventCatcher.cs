using ShadowChimera;
using TheKiwiCoder;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptedLandTales
{
    public class AnimEventCatcher : MonoBehaviour
    {
        [SerializeField] private SpecialAttack m_specialAttack;
        [SerializeField] private Animator m_animator;
        [SerializeField] private UnityEvent m_EndDie;
        [SerializeField] private UnityEvent m_onImpact;         
        private BehaviourTreeRunner m_behaviourTree;
        private AttackManager m_attackManager;
        
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

        public void UseWeaponSkill()
        {
            m_attackManager.UseWeaponSkill();
        }
        public void endPickUp()
        {            
            m_animator.SetBool("isPickUp", false);           
        }
        public void OnEndDie()
        {
            m_EndDie.Invoke();            
        }
        
        public void OnImpact()
        {
            m_onImpact.Invoke();
        }
        public void OnEndAttack()
        {
            m_animator.SetBool("isAttack", false);       
        }
        public void OnEndImpact()
        {
            m_animator.SetBool("isImpact", false);
            
            m_behaviourTree.enabled = true;
        }
    }
}
