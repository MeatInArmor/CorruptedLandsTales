using ShadowChimera;
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
        //[SerializeField] private CharMoveComponentAnimator m_charMoveComponent;
        [SerializeField] private Animator m_animator;
        [SerializeField] private UnityEvent m_EndDie;
        [SerializeField] private UnityEvent m_onImpact;         
        private BehaviourTreeRunner m_behaviourTree;
        //[SerializeField] private InteractItemHandler m_PickUp;
        //private Animator m_animator;
        private void Start()
        {
            m_attackManager = GetComponentInParent<AttackManager>();
            m_behaviourTree = GetComponentInParent<BehaviourTreeRunner>();
            //m_animator = GetComponentInParent<Animator>();
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
            //m_PickUp.HandleItem();
            m_animator.SetBool("isPickUp", false);
            //Debug.Log("PickUp");
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
            m_animator.SetBool("IsImpact", false);
            //m_healthComponent.onImpact.Invoke();
            //onImpact.Invoke();
            m_behaviourTree.enabled = true;
        }
    }
}
