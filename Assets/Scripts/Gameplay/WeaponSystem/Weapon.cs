using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base weapon class
/// </summary>
public class Weapon : MonoBehaviour
{
    public WeaponDetails Details
    {
        get
        {
            return details;
        }
    }
    public float FireTime 
    {
        get
        {
            return fireTime;
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

    private float fireTime;

    /// <summary>
    /// Fire the weapon
    /// </summary>
    public void Fire(Entity.EntityType entityType)
    {
        if (nozzle != null)
        {
            BaseBullet obj = Instantiate(Details.BulletPrefab, nozzle.position, nozzle.rotation);
            obj.SetUp(Details.Damage, Details.BulletSpeed, entityType);
        }
    }

    /// <summary>
    /// To check weapon ready shoot or update
    /// </summary>
    /// <returns></returns>
    public bool WeaponUpdate()
    {
        bool shoot = false;

        if (fireTime >= 1)
        {
            shoot = true;
            fireTime = 0;
        }

        fireTime += Time.deltaTime * (Details.RateOfFire + Random.Range(0, Details.Randomize));
        return shoot;
    }
}
