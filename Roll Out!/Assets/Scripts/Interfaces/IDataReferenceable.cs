using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Interfaces
{
    public interface IDataReferencable<RefType, ParamType>
    {
        RefType objRef { get; set; }
        void SetObjUtilValue(ParamType param);
    }
}
