using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Handlers
{
    public class EventsHandler : MonoBehaviour
    {
        #region Delegates
        delegate void NoArgumentEvent();
        delegate void OneArgumentEvent<T>(T param);
        #endregion
    }
}