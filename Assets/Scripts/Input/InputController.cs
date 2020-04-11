using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic input controller
/// </summary>
public class InputController : MonoBehaviour
{
    private ComponentHolder holder;

    private Vector2 initMousePoint;
    private Vector2 initPlayerPoint;

    /// <summary>
    /// Mono object awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
    }

    /// <summary>
    /// Mono object update
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initMousePoint = GetPoint();
            initPlayerPoint = holder.ObjectEntity.transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            if (holder.MovementController != null)
            {
                holder.MovementController.Node.UpdateTarget(GetRelativePoint()).Execute(holder.ObjectEntity);
            }
        }
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
