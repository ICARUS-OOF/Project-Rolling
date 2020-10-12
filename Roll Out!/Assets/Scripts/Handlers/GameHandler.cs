using ProjectRolling.Data;
using ProjectRolling.Objects;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ProjectRolling.Handlers
{
    public class GameHandler : MonoBehaviour
    {
        #region Singleton
        public static GameHandler singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
        #region Tags
        public static string PLAYER_TAG = "Player";
        #endregion
        #region Scene Data
        public CheckPoint LastCheckpoint;
        #endregion
        #region Static Util Methods
        public static Collider[] GetOverlapSphereColliders(Vector3 pos, float radius)
        {
            Collider[] colliders = Physics.OverlapSphere(pos, radius);
            return colliders;
        }
        public static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        public static void FreeCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public static void FreezeTime()
        {
            Time.timeScale = 0f;
        }
        public static void UnfreezeTime()
        {
            Time.timeScale = 1f;
        }
        #endregion
        #region Util Methods
        public void OnPlayerRespawn()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (LastCheckpoint != null)
            {
                LevelHandler.singleton.playerData.transform.position = LastCheckpoint.transform.position;
            }
        }
        public void OnLevelRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion

    }
}
