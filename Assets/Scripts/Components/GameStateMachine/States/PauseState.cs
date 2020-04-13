using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game paused state
/// </summary>
public class PauseState : State
{
    /// <summary>
    /// On state enter
    /// </summary>
    public override void OnEnter()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// On state exit
    /// </summary>
    public override void OnExit()
    {
        Time.timeScale = 1;
    }
}
