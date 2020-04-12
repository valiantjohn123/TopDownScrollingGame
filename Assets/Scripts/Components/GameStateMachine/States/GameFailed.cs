using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFailed : State
{
    public override void OnEnter()
    {

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
