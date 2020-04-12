using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements collision detector
/// </summary>
public interface ICollisionListner 
{
    /// <summary>
    /// On collision trigger
    /// </summary>
    /// <param name="entity"></param>
    void OnCollision(Entity entity);
}
