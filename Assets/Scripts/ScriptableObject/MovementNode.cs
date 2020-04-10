using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child basic movement objet
/// </summary>
[CreateAssetMenu(fileName = "MoveNode", menuName = "Movement/MoveNode", order = 1)]
public class MovementNode : MovementNodeBase
{
    public Vector2 TowardsPoint;

    /// <summary>
    /// On movement execute
    /// </summary>
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
