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
    public float BulletSpeed;
    public float RateOfFire;
    public float Damage;
    public float Randomize;
}
