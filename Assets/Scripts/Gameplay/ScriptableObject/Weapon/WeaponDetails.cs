using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data holder for weapons
/// </summary>
[CreateAssetMenu(fileName = "WeaponData", menuName = "WeaponData/BaseGun", order = 1)]
public class WeaponDetails : ScriptableObject
{
    public enum BulletType
    {
        Regular
    }

    public BulletType SuitedBullet;
    public BaseBullet BulletPrefab;
    public float RateOfFire;
    public float Damage;

    [System.NonSerialized]
    public float FireTime;

    /// <summary>
    /// To check weapon ready shoot or update
    /// </summary>
    /// <returns></returns>
    public bool WeaponUpdate()
    {
        bool shoot = false;

        if (FireTime >= 1)
        {
            shoot = true;
            FireTime = 0;
        }

        FireTime += Time.deltaTime * RateOfFire;

        return shoot;
    }
}
