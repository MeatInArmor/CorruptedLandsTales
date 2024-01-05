using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "CharacterSO", menuName = "CorruptedLandTales/CharacterSO")]
    public class CharacterSO : ScriptableObject
    {
        public MoveData moveData;
        public HealthData healthData;
        public WeaponSO weapon;
    }

    [System.Serializable]
    public class HealthData
    {
        public float health = 100;
        public float maxHealth = 100;
    }


    [System.Serializable]
    public class MoveData
    {
        public float speed = 5f;
        public float sprintSpeed = 10f;
    }
}
