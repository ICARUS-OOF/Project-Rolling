using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Data
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerPhysics : MonoBehaviour
    {
        [HideInInspector]
        public Rigidbody rb;

        public float speed = 6f;
        public float turnSmoothTime = 0.1f;
        public float turnSmoothVel;
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
    }
}