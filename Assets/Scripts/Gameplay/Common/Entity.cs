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
    public float Health;
    public float CollisionDamage;
    public bool CanTakeDamage;

    /// <summary>
    /// Trigger to indicate health changed
    /// </summary>
    public Action<float> HealthUpdated;

    private float totalHealth = -1;

    /// <summary>
    /// On death trigger
    /// </summary>
    public abstract void OnDeath();

    /// <summary>
    /// Take damage metho
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (CanTakeDamage)
        {
            if (totalHealth < 0)
            {
                totalHealth = Health;
            }
            Health -= damage;

            HealthUpdated?.Invoke(Health / totalHealth);
        }

        if (Health <= 0)
        {
            OnDeath();
        }
    }
}