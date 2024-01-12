using System;
using CorruptedLandTales;
using UnityEngine;

namespace ShadowChimera
{
    public class AnimEventCatcher : MonoBehaviour
    {
        private AttackManager m_attackManager;
        [SerializeField] private SpecialAttack m_specialAttack;
        [SerializeField] private CharMoveComponent m_charMoveComponent;

        private void Start()
        {
            m_attackManager = GetComponentInParent<AttackManager>();
        }

        public void Attack()
        {
            m_attackManager.UseWeapon();
        }

        public void SpecialAttack()
        {
            m_specialAttack.CastSpecialAttack();
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
