using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : State
{
    [SerializeField]
    private Text totalScoreTextBox;

    [SerializeField]
    private LevelUIController levelUIController;

    public override void OnEnter()
    {
        Input.multiTouchEnabled = false;
        Global.CurrentGame.Reset();
        totalScoreTextBox.text = "Score: "+ Global.TotalScore.ToString();
        levelUIController.SetLevelData();
    }

    public override void OnExit()
    {
        
    }

    /// <summary>
    /// Go to game state
    /// </summary>
    public void PlayGame()
    {
        DependencyHolder.MainStateController.ChangeState(StateController.States.Game);
    }
}
