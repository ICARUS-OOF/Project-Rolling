using ProjectRolling.Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Objects
{
    public class CheckPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider col)
        {
            if (col.transform.tag == GameHandler.PLAYER_TAG)
            {
                LevelHandler.singleton.onPlayerReachCheckpoint?.Invoke(this);
            }
        }
    }
}
