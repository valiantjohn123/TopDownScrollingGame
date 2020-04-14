﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player abilities handler
/// </summary>
public class PlayerAbilityHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject shieldSprite;

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
        switch (data.Type)
        {
            case PowerUps.PowerUpType.Shield:
                StartCoroutine(UserShield(data));
                break;
            case PowerUps.PowerUpType.Missile:
                InputController.SpecialWeaponFire?.Invoke(0);
                break;
            case PowerUps.PowerUpType.Torpidoes:
                StartCoroutine(FireToprpidoes(data));
                break;
        }
    }

    /// <summary>
    /// Use player shield
    /// </summary>
    /// <returns></returns>
    private IEnumerator UserShield(PowerUps.PowerUpData data)
    {
        shieldSprite.SetActive(true);
        holder.ObjectEntity.CanTakeDamage = false;
        yield return new WaitForSeconds(data.ExpireTime);
        holder.ObjectEntity.CanTakeDamage = true;
        shieldSprite.SetActive(false);
    }

    /// <summary>
    /// Fire the torpedios
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private IEnumerator FireToprpidoes(PowerUps.PowerUpData data)
    {
        float interval = 0;
        float timer = 0;
        while (timer <= 1)
        {
            if (interval >= 8)
            {
                InputController.SpecialWeaponFire?.Invoke(1);
                interval = 0;
            }
            interval++;
            timer += Time.deltaTime / data.ExpireTime;
            yield return null;
        }
    }

    /// <summary>
    /// On object destroyed
    /// </summary>
    private void OnDestroy()
    {
        UseAbility -= AbilityUsed;
    }
}
