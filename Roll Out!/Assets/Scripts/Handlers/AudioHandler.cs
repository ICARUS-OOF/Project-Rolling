using ProjectRolling.Serializables;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Handlers
{
    public class AudioHandler : MonoBehaviour
    {
        #region Singleton
        public static AudioHandler singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }
        #endregion
        public AudioSource source;
        public List<Sound> sounds = new List<Sound>();
        public Sound GetSound(string _ID)
        {
            Sound sound = new Sound();
            for (int i = 0; i < sounds.Count; i++)
            {
                if (sounds[i].ID == _ID)
                {
                    sound = sounds[i];
                }
            }
            return sound;
        }
        public void PlaySound(string _ID)
        {
            source.PlayOneShot(GetSound(_ID).clip);
        }
    }
}