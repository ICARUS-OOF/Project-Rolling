using ProjectRolling.Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectRolling.Objects
{
    public class LevelTeleporter : MonoBehaviour
    {
        [SerializeField] private GameObject RotatingSquare;
        [SerializeField] private string SceneName = "Level01";
        private void Update()
        {
            Collider[] colliders = GameHandler.GetOverlapSphereColliders(transform.position, 10f);
            foreach (Collider col in colliders)
            {
                if (col.transform.tag == GameHandler.PLAYER_TAG)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        SceneManager.LoadScene(SceneName);
                    }
                }
            }
            RotatingSquare.transform.Rotate(new Vector3(0f, 0f, 20f * Time.fixedDeltaTime));
        }
    }
}