using UnityEngine;

namespace CorruptedLandTales
{
    public class BossEventCatcher : MonoBehaviour
    {
        [SerializeField] private BossAttackManager m_attackManager;
        public bool flag = false;
        
        public void Attack(string typeOfAttack)
        {
            m_attackManager.BossAttack(typeOfAttack);
        }

        public void EndAttack()
        {
            flag = true;
        }
    }
}
