using System;
using UnityEngine;

/// <summary>
/// Entity base class
/// This is a common class used for both player and enemies
/// This contains basic properties of entities
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
        if (CanTakeDamage && ScreenPositionUtility.InScreen(transform.position, Vector2.one * 0.25f) && DependencyHolder.MainStateController.CurrentState.StateID == StateController.States.Game)
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
            SignalOnDeath();
            OnDeath();
        }
    }

    /// <summary>
    /// Signals on death for listner
    /// </summary>
    private void SignalOnDeath()
    {
        var dListner = GetComponent<IDeathEffectListner>();
        if (dListner != null)
        {
            dListner.OnDeath();
        }
    }
}