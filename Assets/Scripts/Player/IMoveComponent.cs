using UnityEngine;

namespace CorruptedLandTales
{
    public interface IMoveComponent
    {
        void Init(float speed, float sprintSpeed);

        Vector3 velocity { get; }
    }
}
