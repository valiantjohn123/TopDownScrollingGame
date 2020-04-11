using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : State
{
    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    /// <summary>
    /// Go to game state
    /// </summary>
    public void PlayGame()
    {
        StateController.ChangeState(StateController.States.Game);
    }
}
