using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryBullet : BaseBullet
{
    /// <summary>
    /// Mono update
    /// </summary>
    private void Update()
    {
        transform.position = Vector2.Lerp(Position, Position + (Direction * Range), Step);

        Step += Time.deltaTime * Speed;
    }
}
