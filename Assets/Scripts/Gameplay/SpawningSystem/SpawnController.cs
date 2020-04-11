using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base spawn controller
/// </summary>
public abstract class SpawnController : MonoBehaviour
{
    public ObjectSpawner Spawner;
    public bool InProgress;

    /// <summary>
    /// Set start operation
    /// </summary>
    public void InitOperation()
    {
        InProgress = true;
        Started();
    }

    /// <summary>
    /// Set stop operation
    /// </summary>
    public void StopOperation()
    {
        InProgress = false;
        Ended();
    }

    /// <summary>
    /// Operation started trigger
    /// </summary>
    public abstract void Started();

    /// <summary>
    /// Operation ended
    /// </summary>
    public abstract void Ended();
}
