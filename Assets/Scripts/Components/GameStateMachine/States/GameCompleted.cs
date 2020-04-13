using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompleted : State
{
    public override void OnEnter()
    {
        if (Global.CurrentGame.CurrentLevel == Global.LastUnlockedLevel)
            Global.LastUnlockedLevel++;

        Global.CurrentGame.SaveData();
    }

    public override void OnExit()
    {
        
    }

    /// <summary>
    /// Continue to next level
    /// </summary>
    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
