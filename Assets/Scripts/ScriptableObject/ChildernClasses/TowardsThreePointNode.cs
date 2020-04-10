using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child basic movement objet
/// </summary>
[CreateAssetMenu(fileName = "TowardsThreePoint", menuName = "Movement/TowardsMoveThreePoint", order = 1)]
public class TowardsThreePointNode : MovementNodeBase
{
    public Vector2 TowardsPoint;

    private Vector2 targetPoint
    {
        get
        {
            return initPos + TowardsPoint;
        }
    }
    private Vector2 initPos;
    private Vector2 midPoint;

    /// <summary>
    /// Will be called once
    /// </summary>
    public override void OnSetUp()
    {
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
