using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public interface IAttackItem
    {
        void Use();
        void Show();
        void Hide();
        void DestroySelf();
        void Initialize(WeaponSO data);
    }
}
