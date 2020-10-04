using ProjectRolling.Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Objects
{
    public class LevelTeleporter : MonoBehaviour
    {
        [SerializeField] private GameObject InfoUI;
        private void Update()
        {
            Collider[] colliders = GameHandler.GetOverlapSphereColliders(transform.position, 10f);
            foreach (Collider col in colliders)
            {
                if (col.transform.tag == "Player")
                {
                    InfoUI.SetActive(true);
                    break;
                }
                InfoUI.SetActive(false);
            }
            if (colliders.Length == 0)
            {
                InfoUI.SetActive(false);
            }
        }
    }
}