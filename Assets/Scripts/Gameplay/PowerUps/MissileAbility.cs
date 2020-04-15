using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ability class for Missile weapon
/// </summary>
public class MissileAbility : Ability
{
    /// <summary>
    /// Fire missile
    /// </summary>
    /// <param name="data"></param>
    /// <param name="entity"></param>
    public override void Activate(PowerUps.PowerUpData data, Entity entity)
    {
        InputController.SpecialWeaponFire?.Invoke(0);
    }
}
