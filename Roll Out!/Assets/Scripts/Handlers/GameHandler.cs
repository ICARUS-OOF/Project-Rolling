using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Handlers
{
    public class GameHandler : MonoBehaviour
    {
        public static Collider[] GetOverlapSphereColliders(Vector3 pos, float radius)
        {
            Collider[] colliders = Physics.OverlapSphere(pos, radius);
            return colliders;
        }
    }
}
