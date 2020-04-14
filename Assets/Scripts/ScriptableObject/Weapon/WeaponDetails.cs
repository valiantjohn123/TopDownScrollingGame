using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data holder for weapon details
/// </summary>
[CreateAssetMenu(fileName = "WeaponData", menuName = "WeaponData/BaseGun", order = 1)]
public class WeaponDetails : ScriptableObject
{
    /// <summary>
    /// Bullet that needs to be spawned
    /// </summary>
    public BaseBullet BulletPrefab;
    public float BulletSpeed;
    public float RateOfFire;
    public float Damage;
    /// <summary>
    /// Amount of randomization that needs to be added to rate of fire
    /// </summary>
    public float Randomize;
}
