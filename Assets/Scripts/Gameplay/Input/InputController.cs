using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Basic input controller
/// </summary>
public class InputController : MonoBehaviour
{
    private ComponentHolder holder;

    private bool initCompleted;

    private Vector2 initMousePoint;
    private Vector2 initPlayerPoint;

    public static Action<int> SpecialWeaponFire;

    /// <summary>
    /// Mono object awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
        SpecialWeaponFire += FireSpecialWeapons;
    }

    /// <summary>
    /// Mono object update
    /// </summary>
    private void Update()
    {
        if (initCompleted && Input.GetMouseButtonDown(0))
        {
            SetInitData();
        }

        if (Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == null)
        {
            //Control primary weapon
            if (initCompleted && holder.WeaponsController != null)
            {
                holder.WeaponsController.FirePrimaryWeapons();
            }
            //Control movement
            if (holder.MovementController != null)
            {
                if (!initCompleted)
                {
                    if (holder.MovementController.Node.GetType() == typeof(MovePlayer))
                    {
                        SetInitData();
                        initCompleted = true;
                    }
                }

                holder.MovementController.Node.UpdateTarget(GetRelativePoint()).Execute(holder.ObjectEntity);
            }
        }
    }

    /// <summary>
    /// Mono on destroy
    /// </summary>
    private void OnDestroy()
    {
        SpecialWeaponFire -= FireSpecialWeapons;
    }

    /// <summary>
    /// Fire the special weapons
    /// </summary>
    /// <param name="index"></param>
    private void FireSpecialWeapons(int index)
    {
        if (initCompleted && holder.WeaponsController != null)
        {
            holder.WeaponsController.FireSpecialWeapon(index);
        }
    }

    /// <summary>
    /// To set the init data
    /// </summary>
    private void SetInitData()
    {
        initMousePoint = GetPoint();
        initPlayerPoint = holder.ObjectEntity.transform.position;
    }

    /// <summary>
    ///  Get relative world point from mouuse position
    /// </summary>
    /// <returns></returns>
    private Vector2 GetRelativePoint()
    {
        return (initPlayerPoint - initMousePoint) + GetPoint();
    }

    /// <summary>
    /// Get world point from mouuse position
    /// </summary>
    /// <returns></returns>
    private Vector2 GetPoint()
    {
        return holder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
