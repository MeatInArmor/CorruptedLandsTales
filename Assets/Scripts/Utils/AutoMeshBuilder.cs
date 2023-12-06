using Unity.AI.Navigation;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AutoMeshBuilder : MonoBehaviour
    {
        private void Awake()
        {
            var surfaces = GetComponents<NavMeshSurface>();
            foreach (var surface in surfaces)
            {
                surface.BuildNavMesh();
            }
        }
    }
}
