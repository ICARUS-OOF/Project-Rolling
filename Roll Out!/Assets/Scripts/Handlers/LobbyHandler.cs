using ProjectRolling.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectRolling.Handlers
{
    public class LobbyHandler : MonoBehaviour
    {
        #region Singleton
        public static LobbyHandler singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
        #region Start Method
        private void Start()
        {
            onPlayerRestart += OnPlayerRestart;
            onLobbyQuit += OnLobbyQuit;
        }
        #endregion
        #region Events
        public NoArgumentEvent onPlayerRestart;
        public NoArgumentEvent onLobbyQuit;
        #endregion
        #region Event Subscribers
        void OnPlayerRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        void OnLobbyQuit()
        {
            SceneManager.LoadScene("Menu");
        }
        #endregion
    }
}