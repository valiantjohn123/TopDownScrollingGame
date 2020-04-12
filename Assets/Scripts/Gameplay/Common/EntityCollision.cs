using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity collision detector
/// </summary>
public class EntityCollision : MonoBehaviour
{
    private ICollisionListner listener;
    private ComponentHolder holder;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
        listener = holder.CollisionListner.GetComponent<ICollisionListner>();
    }

    /// <summary>
    /// Mono on trigger enter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (listener == null)
        {
            Destroy(this);
            return;
        }

        var entity = other.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            listener.OnCollision(entity);
        }
    }
}
