using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : SpawnController
{
    #region Helper class
    [System.Serializable]
    public class EnemySpawnStashElement 
    {
        public EnemyEntity.EnemyType Type;
        public GameObject EnemyPrefab;
    }
    #endregion

    [SerializeField]
    private List<EnemySpawnStashElement> enemyStash;

    private int spawnedEnemies;
    private int secondsCount;
    private float timer;

    /// <summary>
    /// Operation started trigger
    /// </summary>
    public override void Started()
    {
        spawnedEnemies = 0;
        secondsCount = 0;
        timer = 0;
    }

    /// <summary>
    /// Operation ended trigger
    /// </summary>
    public override void Ended()
    {
        //Do nothing for now
    }

    /// <summary>
    /// Mono update
    /// </summary>
    private void Update()
    {
        if (!InProgress)
            return;

        if (timer >= 1f)
        {
            CheckSpawnValidity();
            secondsCount++;
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    /// <summary>
    /// To check spawn validity
    /// </summary>
    private void CheckSpawnValidity()
    {
        if (Global.CurrentGame.LevelData != null)
        {
            for (int i = 0; i < Global.CurrentGame.LevelData.LevelSpawnList.Count; i++)
            {
                LevelDataBase.EnemySpawnDetails data = Global.CurrentGame.LevelData.LevelSpawnList[i];
                if (data.InTime <= secondsCount && !data.IsSpawned)
                {
                    EnemySpawnStashElement enemy = enemyStash.Find(en => en.Type == data.Type);
                    Spawner.SpawnEnemy(enemy.EnemyPrefab, data);
                    data.IsSpawned = true;
                    spawnedEnemies++;
                }
            }

            if (spawnedEnemies == Global.CurrentGame.LevelData.LevelSpawnList.Count)
            {
                StopOperation();
            }
        }
    }
}
