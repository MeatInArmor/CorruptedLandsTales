using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public interface IAttackItem
    {
        void Attack();
        void Show();
        void Hide();
        void DestroySelf();
    }
}
