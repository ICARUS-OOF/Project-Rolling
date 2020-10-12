using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Interfaces
{
    public interface IEntity
    {
        bool canDamage { get; set; }
        float Health { get; set; }
        void Damage(float _health);
    }
}