using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child basic movement objet
/// </summary>
[CreateAssetMenu(fileName = "TowardsNode", menuName = "Movement/TowardsMove", order = 1)]
public class TowardsNode : MovementNodeBase
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

    /// <summary>
    /// Will be called once
    /// </summary>
    public override void OnSetUp()
    {
        if (ParentEntity != null)
            initPos = ParentEntity.transform.position;
    }

    /// <summary>
    /// On step update
    /// </summary>
    /// <param name="step"></param>
    public override void OnStep(float step)
    {
        if (ParentEntity != null)
            ParentEntity.transform.position = Vector2.Lerp(initPos, targetPoint, step);
    }
}
