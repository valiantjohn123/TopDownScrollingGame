using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    private ComponentHolder holder;
    [SerializeField]
    private List<Weapon> primaryWeapons;
    [SerializeField]
    private List<Weapon> specialWeapons;

    public static Action<int, float> WeaponUpdated;

    /// <summary>
    /// Mono on awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
    }

    /// <summary>
    /// Fire primary weapons
    /// </summary>
    public void FirePrimaryWeapons()
    {
        for (int i = 0; i < primaryWeapons.Count; i++)
        {
            var weapon = primaryWeapons[i];
            if (weapon.WeaponUpdate())
            {
                weapon.Fire(holder.ObjectEntity.Type);
            }
        }
    }

    /// <summary>
    /// Fire primary weapons
    /// </summary>
    public void FireSpecialWeapon(int index)
    {
        var weapon = specialWeapons[index];
        weapon.Fire(holder.ObjectEntity.Type);
    }

    /// <summary>
    /// Mono on update
    /// </summary>
    private void Update()
    {
        for (int i = 0; i < specialWeapons.Count; i++)
        {
            specialWeapons[i].WeaponUpdate();
            WeaponUpdated?.Invoke(i, specialWeapons[i].FireTime);
        }
    }
}
