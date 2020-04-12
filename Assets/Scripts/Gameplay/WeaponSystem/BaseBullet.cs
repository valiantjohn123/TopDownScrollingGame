using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour, ICollisionListner
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
    public void SetUp(float dmg, float speed, Entity.EntityType type)
    {
        Type = type;
        Damage = dmg;
        Speed = speed;
        Direction = transform.up;
        Position = transform.position;
    }

    ///// <summary>
    ///// Mono on trigger enter
    ///// </summary>
    ///// <param name="other"></param>
    //public void OnTrigger(Collider2D other)
    //{
    //    var entity = other.gameObject.GetComponent<Entity>();
    //    if (entity != null && entity.Type != Type)
    //    {
    //        if (entity.TakeDamage(Damage))
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    /// <summary>
    /// On collision trigger
    /// </summary>
    /// <param name="entity"></param>
    public void OnCollision(Entity entity)
    {
        if (entity != null && entity.Type != Type)
        {
            if (entity.TakeDamage(Damage))
            {
                Destroy(gameObject);
            }
        }
    }
}
