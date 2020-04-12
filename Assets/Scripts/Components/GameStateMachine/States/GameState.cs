using System;
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
        DependencyHolder.Enemies = new List<Entity>();
        EnemyEntity.EnemiesCountChanged += EnemyCountChanged;
        spawnControllers.ForEach(sp => sp.InitOperation());
    }

    /// <summary>
    /// Enemy count has changed
    /// </summary>
    /// <param name="count"></param>
    private void EnemyCountChanged(int count)
    {
        if (count == 0)
        {
            SpawnController spawnController = spawnControllers.Find(ft => ft.GetType() == typeof(EnemySpawnController));
            if (!spawnController.InProgress && DependencyHolder.MainStateController.CurrentState.StateID == StateController.States.Game)
            {
                DependencyHolder.MainStateController.ChangeState(StateController.States.GameWin);
            }
        }
    }

    /// <summary>
    /// On state exit
    /// </summary>
    public override void OnExit()
    {
        EnemyEntity.EnemiesCountChanged -= EnemyCountChanged;
        spawnControllers.ForEach(sp => sp.StopOperation());
    }
}
