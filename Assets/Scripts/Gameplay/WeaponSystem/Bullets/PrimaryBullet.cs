﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Primary bullet behaviour script
/// </summary>
public class PrimaryBullet : BaseBullet
{
    /// <summary>
    /// On hit success
    /// </summary>
    public override void OnHit(Entity entity)
    {
        //Do nothing here
    }

    /// <summary>
    /// Mono update
    /// </summary>
    private void Update()
    {
        transform.position = Vector2.Lerp(Position, Position + (Direction * Range), Step);

        Step += Time.deltaTime * Speed;
    }
}
