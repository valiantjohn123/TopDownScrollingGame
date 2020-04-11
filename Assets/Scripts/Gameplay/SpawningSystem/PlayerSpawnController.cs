using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : SpawnController
{
    [SerializeField]
    private GameObject playerPrefab;

    /// <summary>
    /// Operation started trigger
    /// </summary>
    public override void Started()
    {
        Spawner.SpawnPlayer(playerPrefab);
    }

    /// <summary>
    /// Operation ended trigger
    /// </summary>
    public override void Ended()
    {
        //Do nothing for now
    }
}
