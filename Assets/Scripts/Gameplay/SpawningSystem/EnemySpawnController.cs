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

    [SerializeField]
    private LevelDataBase levelData;

    private int secondsCount;
    private float timer;

    /// <summary>
    /// Operation started trigger
    /// </summary>
    public override void Started()
    {
        //Do nothing here
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
        if (levelData != null)
        {
            for (int i = 0; i < levelData.LevelSpawnList.Count; i++)
            {
                LevelDataBase.EnemySpawnDetails data = levelData.LevelSpawnList[i];
                if (data.InTime <= secondsCount && !data.IsSpawned)
                {
                    EnemySpawnStashElement enemy = enemyStash.Find(en => en.Type == data.Type);
                    Spawner.SpawnEnemy(enemy.EnemyPrefab, data.SpawnPoint);
                    data.IsSpawned = true;
                }
            }
        }
    }
}
