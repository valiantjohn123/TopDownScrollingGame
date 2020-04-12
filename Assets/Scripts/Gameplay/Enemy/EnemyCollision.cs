using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy collision handler
/// </summary>
public class EnemyCollision : MonoBehaviour, ICollisionListner
{
    private ComponentHolder holder;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
    }

    /// <summary>
    /// On collision trigger
    /// </summary>
    /// <param name="entity"></param>
    public void OnCollision(Entity entity)
    {
        if (entity.Type == Entity.EntityType.Player)
        {
            if (entity.TakeDamage(holder.ObjectEntity.CollisionDamage))
            {
                Destroy(gameObject);
            }
        }
    }
}
