using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base movement node
/// </summary>
public abstract class MovementNodeBase : ScriptableObject
{
    public abstract void Execute();
}
