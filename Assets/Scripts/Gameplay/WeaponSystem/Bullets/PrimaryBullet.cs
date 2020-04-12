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

    ///// <summary>
    ///// Ontrigger enter
    ///// </summary>
    ///// <param name="other"></param>
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    OnTrigger(other);
    //}
}
