using ProjectRolling.Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectRolling.Objects
{
    public class Finish : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.Rotate(new Vector3(0f, 8f * Time.fixedDeltaTime, 0f));
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == GameHandler.PLAYER_TAG)
            {
                LevelHandler.singleton.onCompleteLevel?.Invoke();
            }
        }
    }
}