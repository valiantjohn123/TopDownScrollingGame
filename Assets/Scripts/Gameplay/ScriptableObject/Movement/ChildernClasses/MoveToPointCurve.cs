using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child basic movement objet
/// </summary>
[CreateAssetMenu(fileName = "MoveToPointCurve", menuName = "Movement/MoveToPointCurve", order = 1)]
public class MoveToPointCurve : MovementNodeBase
{
    [SerializeField]
    private Vector2 targetPoint;
    private Vector2 initPos;
    private Vector2 midPoint;

    /// <summary>
    /// Will be called once
    /// </summary>
    public override void OnSetUp()
    {
        if (ParentEntity != null)
            initPos = ParentEntity.transform.position;
        midPoint = new Vector2(initPos.x, targetPoint.y);
    }

    /// <summary>
    /// On step update
    /// </summary>
    /// <param name="step"></param>
    public override void OnStep(float step)
    {
        if (ParentEntity != null)
            ParentEntity.transform.position = Vector2.Lerp(Vector2.Lerp(initPos, midPoint, step), Vector2.Lerp(midPoint, targetPoint, step), step);
    }
}
