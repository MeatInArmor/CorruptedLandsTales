using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public interface IMoveComponent
    {
        void Init(float speed, float sprintSpeed);

        //Vector3 velocity { get; }
    }
}
