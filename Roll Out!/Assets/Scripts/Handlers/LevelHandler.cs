using ProjectRolling.Data;
using ProjectRolling.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectRolling.Handlers
{
    public class LevelHandler : MonoBehaviour
    {
        #region Singleton
        public static LevelHandler singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
        #region Properties
        public PlayerData playerData;
        #endregion
        #region Events
        public NoArgumentEvent onCompleteLevel;
        public NoArgumentEvent onPlayerCrack;
        public OneArgumentEvent<CheckPoint> onPlayerReachCheckpoint;

        public NoArgumentEvent onLevelRestart;
        public NoArgumentEvent onLevelQuit;
        #endregion
        #region Start
        private void Start()
        {
            onCompleteLevel += CompletedLevel;
            onPlayerCrack += PlayerCracked;
            onPlayerReachCheckpoint += OnPlayerReachCheckpoint;
            onLevelQuit += OnLevelQuit;
        }
        #endregion
        #region Event Subscribers
        void CompletedLevel()
        {
            Debug.Log("Completed level!");
        }
        void PlayerCracked()
        {
            GameHandler.singleton.OnPlayerRespawn();
        }
        void OnPlayerReachCheckpoint(CheckPoint cp)
        {
            GameHandler.singleton.LastCheckpoint = cp;
        }
        void OnLevelQuit()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Lobby");
        }
        #endregion
    }
}