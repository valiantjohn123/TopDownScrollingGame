using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base weapon class
/// </summary>
[RequireComponent(typeof(WeaponsController))]
public class Weapon : MonoBehaviour
{
    public WeaponDetails Details
    {
        get
        {
            return details;
        }
    }

    [SerializeField]
    private WeaponDetails details;
    [SerializeField]
    private Transform nozzle;

    public bool IsAvailable 
    {
        get;
        private set;
    }

    /// <summary>
    /// Fire the weapon
    /// </summary>
    public void Fire(Entity.EntityType entityType)
    {
        if (nozzle != null)
        {
            BaseBullet obj = Instantiate(details.BulletPrefab, nozzle.position, nozzle.rotation);
            obj.SetUp(details.Damage, entityType);
        }
    }
}
