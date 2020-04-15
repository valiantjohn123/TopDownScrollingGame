using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ability class for torpedo weapon
/// </summary>
public class TorpedosAbiliy : Ability
{
    /// <summary>
    /// Activate torpedos
    /// </summary>
    /// <param name="data"></param>
    /// <param name="entity"></param>
    public override void Activate(PowerUps.PowerUpData data, Entity entity)
    {
        StartCoroutine(FireTorpidoes(data));
    }

    /// <summary>
    /// Fire the torpedios
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private IEnumerator FireTorpidoes(PowerUps.PowerUpData data)
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
}
