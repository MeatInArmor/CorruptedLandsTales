using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class InitCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterSO m_data;
        [SerializeField] private Character m_character;

        private void Start()
        {
            if (m_character != null)
            {
                m_character.Initialize(m_data);
            }
        }
    }
}
