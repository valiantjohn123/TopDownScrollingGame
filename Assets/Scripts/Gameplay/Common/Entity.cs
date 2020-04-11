using System;
using UnityEngine;

/// <summary>
/// Entity base class
/// </summary>
public abstract class Entity : MonoBehaviour
{
    #region Enums
    public enum EntityType { Player, Enemy }
    #endregion

    public EntityType Type;
    public int Health;
    public bool CanTakeDamage;

    /// <summary>
    /// On death trigger
    /// </summary>
    public abstract void OnDeath();

    /// <summary>
    /// Take damage metho
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        if (CanTakeDamage)
            Health -= damage;

        if (Health <= 0)
        {
            OnDeath();
        }
    }
}