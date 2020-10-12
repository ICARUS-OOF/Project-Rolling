using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Handlers
{
    public class PlayerUI : MonoBehaviour
    {
        #region Singleton
        public static PlayerUI singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
        public GameObject pauseMenuUI;
        public bool isPaused = false;
        public bool canPause = true;
        private void Start()
        {
            Resume();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (canPause)
                {
                    Pause();
                }
            }
        }
        public void Pause()
        {
            isPaused = true;
            pauseMenuUI.SetActive(true);
            GameHandler.FreeCursor();
        }
        public void Resume()
        {
            isPaused = false;
            pauseMenuUI.SetActive(false);
            GameHandler.LockCursor();
        }
        public void Restart()
        {
            LevelHandler.singleton.onLevelRestart?.Invoke();
        }
        public void Respawn()
        {
            if (LevelHandler.singleton != null)
            {
                LevelHandler.singleton.onPlayerCrack?.Invoke();
            }
            if (MenuHand)
        }
        public void Quit()
        {
            LevelHandler.singleton.onLevelQuit?.Invoke();
        }
        public void ExitGame()
        {
            Debug.Log("Exiting Game...");
            Application.Quit();
        }
    }
} 