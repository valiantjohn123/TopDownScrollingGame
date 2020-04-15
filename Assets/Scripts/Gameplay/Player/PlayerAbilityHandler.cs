using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player abilities handler
/// </summary>
public class PlayerAbilityHandler : MonoBehaviour
{
    [SerializeField]
    private Ability[] abilities;

    private ComponentHolder holder;

    public static Action<PowerUps.PowerUpData> UseAbility;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
        UseAbility += AbilityUsed;
    }

    /// <summary>
    /// Player powerups code
    /// </summary>
    /// <param name="type"></param>
    private void AbilityUsed(PowerUps.PowerUpData data)
    {
        abilities[(int)data.Type].Activate(data, holder.ObjectEntity);
    }

    /// <summary>
    /// On object destroyed
    /// </summary>
    private void OnDestroy()
    {
        UseAbility -= AbilityUsed;
    }
}
