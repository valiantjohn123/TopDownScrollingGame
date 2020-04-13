using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for a state
/// </summary>
public abstract class State : MonoBehaviour
{
    public StateController.States StateID;
    public StateController.States BackID;

    public List<GameObject> StateObjects;

    /// <summary>
    /// Called on state enter
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    /// Called on state exit
    /// </summary>
    public abstract void OnExit();

    /// <summary>
    /// Load state
    /// </summary>
    public void LoadState()
    {
        OnEnter();
        StateObjects.ForEach(item => item.SetActive(true));
    }

    /// <summary>
    /// Unload state
    /// </summary>
    public void UnloadState()
    {
        StateObjects.ForEach(item => 
        {   if (item != null)
                item.SetActive(false);
            else
                Debug.Log(item);
        });
        OnExit();
    }
}
