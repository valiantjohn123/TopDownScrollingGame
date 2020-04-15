using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ability class for weapon shield
/// </summary>
public class ShieldAbility : Ability
{
    [SerializeField]
    private GameObject shieldSprite;

    /// <summary>
    /// Activate shield
    /// </summary>
    /// <param name="data"></param>
    /// <param name="entity"></param>
    public override void Activate(PowerUps.PowerUpData data, Entity entity)
    {
        StartCoroutine(UserShield(data, entity));
    }

    /// <summary>
    /// Use player shield
    /// </summary>
    /// <returns></returns>
    private IEnumerator UserShield(PowerUps.PowerUpData data, Entity entity)
    {
        shieldSprite.SetActive(true);
        entity.CanTakeDamage = false;
        yield return new WaitForSeconds(data.ExpireTime);
        entity.CanTakeDamage = true;
        shieldSprite.SetActive(false);
    }
}
