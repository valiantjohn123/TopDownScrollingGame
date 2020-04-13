using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child basic movement objet
/// </summary>
[CreateAssetMenu(fileName = "MoveToPoint", menuName = "Movement/MoveToPoint", order = 1)]
public class MoveToPoint : MovementNodeBase
{
    [SerializeField]
    private Vector2 targetPoint;

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
