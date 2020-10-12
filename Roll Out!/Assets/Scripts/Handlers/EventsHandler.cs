using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Events
{
    #region Delegates
    public delegate void NoArgumentEvent();
    public delegate void OneArgumentEvent<T>(T param);
    #endregion
}