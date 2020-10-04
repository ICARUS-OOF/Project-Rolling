﻿using ProjectRolling.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Movement
{
    [RequireComponent(typeof(PlayerPhysics))]
    public class PlayerMovement : MonoBehaviour
    {
        PlayerPhysics physics;
        public Transform cam;
        private void Start()
        {
            physics = GetComponent<PlayerPhysics>();
        }
        private void Update()
        {
            float horiz = Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");

            Vector3 dir = new Vector3(horiz, 0f, vert).normalized;

            if (dir.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                physics.rb.AddForce(moveDir.normalized * physics.speed * Time.deltaTime);
            }
        }
    }
}
