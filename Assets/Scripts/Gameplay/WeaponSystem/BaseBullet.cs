using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    public float Range;
    public float Speed;
    public float Damage;
    public float Step;
    public Entity.EntityType Type;
    public Vector2 Position;
    public Vector2 Direction;

    /// <summary>
    /// Set up the bullet object
    /// </summary>
    /// <param name="dmg"></param>
    /// <param name="type"></param>
    public void SetUp(float dmg, Entity.EntityType type)
    {
        Type = type;
        Damage = dmg;
        Direction = transform.up;
        Position = transform.position;
    }

    /// <summary>
    /// Mono on trigger enter
    /// </summary>
    /// <param name="other"></param>
    public void OnTrigger(Collider2D other)
    {
        var entity = other.gameObject.GetComponent<Entity>();
        if (entity != null && entity.Type != Type)
        {
            entity.TakeDamage(Damage);
        }
    }
}
