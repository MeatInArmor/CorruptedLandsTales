using UnityEditor;
using UnityEngine;

namespace CorruptedLandTales
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        
        int group { get; }
    }
}