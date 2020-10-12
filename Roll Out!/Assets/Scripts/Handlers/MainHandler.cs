using UnityEngine;
using UnityEngine.SceneManagement;
namespace ProjectRolling.Handlers
{
    public class MainHandler : MonoBehaviour
    {
        #region References
        public Texture2D cracks;
        #endregion
        #region Start Method
        private void Start()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("MainHandler");
            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
            SceneManager.sceneLoaded += OnSceneLoaded;
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }
        #endregion
        #region SceneLoaded Method
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Time.timeScale = 1f;
        }
        #endregion
        #region Update Method
        private void Update()
        {
            
        }
        #endregion
        #region Singleton
        public static MainHandler singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
    }
}