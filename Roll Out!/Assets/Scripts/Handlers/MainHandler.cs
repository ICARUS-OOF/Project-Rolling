using UnityEngine;
using UnityEngine.SceneManagement;
namespace ProjectRolling.Handlers
{
    public class MainHandler : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
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
        }
    }
}