using ProjectRolling.Data;
using ProjectRolling.Events;
using ProjectRolling.Objects;
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
        public GameObject DeathScreen;
        #endregion
        #region Events
        public NoArgumentEvent onCompleteLevel;
        public OneArgumentEvent<bool> onPlayerCrack;
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
            onLevelRestart += OnLevelRestart;
        }
        #endregion
        #region Event Subscribers
        void CompletedLevel()
        {
            Debug.Log("Completed level!");
            PlayerUI.singleton.canPause = false;
        }
        void OnLevelRestart()
        {
            GameHandler.singleton.OnLevelRestart();
            PlayerUI.singleton.canPause = true;
        }
        void PlayerCracked(bool ActivateDeathScreen)
        {
            DeathScreen.SetActive(ActivateDeathScreen);
            if (!ActivateDeathScreen)
            {
                GameHandler.singleton.OnPlayerRespawn();
            }
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