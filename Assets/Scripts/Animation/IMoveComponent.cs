using UnityEngine;

namespace CorruptedLandTales
{
    internal interface IMoveComponent
    {
        void Init(float speed, float sprintSpeed);

        Vector3 velocity { get; }
    }
}