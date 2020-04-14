﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Effects handler
/// </summary>
public class EffectHandler : MonoBehaviour, IDeathEffectListner
{
    [SerializeField]
    private GameObject deathExplosion;

    /// <summary>
    /// On death listner
    /// </summary>
    public void OnDeath()
    {
        if (deathExplosion != null)
            Instantiate(deathExplosion, transform.position, transform.rotation);
    }
}
