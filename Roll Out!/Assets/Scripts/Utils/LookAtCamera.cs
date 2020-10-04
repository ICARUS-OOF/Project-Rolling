using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Utils
{
    public class LookAtCamera : MonoBehaviour
    {
        private void LateUpdate()
        {
            Camera cam = Camera.main;

            transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
                cam.transform.rotation * Vector3.up);
        }
    }
}