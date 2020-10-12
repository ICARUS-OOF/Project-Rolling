using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Serializables
{
    [System.Serializable]
    public struct Sound
    {
        public string ID;
        public AudioClip clip;
    }
}