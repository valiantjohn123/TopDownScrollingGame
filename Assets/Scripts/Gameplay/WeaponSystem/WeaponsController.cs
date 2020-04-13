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
}
