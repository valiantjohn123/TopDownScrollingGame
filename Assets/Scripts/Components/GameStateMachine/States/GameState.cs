using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    [SerializeField]
    private List<SpawnController> spawnControllers;

    /// <summary>
    /// On state enter
    /// </summary>
    public override void OnEnter()
    {
        spawnControllers.ForEach(sp => sp.InitOperation());
    }

    /// <summary>
    /// On state exit
    /// </summary>
    public override void OnExit()
    {
        spawnControllers.ForEach(sp => sp.StopOperation());
    }
}
