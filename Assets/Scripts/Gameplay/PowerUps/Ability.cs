using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player ability base class
/// </summary>
public abstract class Ability: MonoBehaviour
{
    /// <summary>
    /// Activate the ability
    /// </summary>
    /// <param name="data"></param>
    /// <param name="entity"></param>
    public abstract void Activate(PowerUps.PowerUpData data, Entity entity);
}
