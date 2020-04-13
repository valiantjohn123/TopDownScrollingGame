using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object spawn handler
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    #region Helper objects
    public enum EnemySpawnPoints
    {
        Point1, Point2, Point3, Point4, Point5
    }

    [System.Serializable]
    public class EnemySpawnPointObjects
    {
        public EnemySpawnPoints Point;
        public Transform PointObject;
    }
    #endregion

    [SerializeField]
    private Transform playerSpawnPoint;

    [SerializeField]
    private List<EnemySpawnPointObjects> enemySpawnPoints;

    /// <summary>
    /// Spawn player
    /// </summary>
    /// <param name="playerObject"></param>
    public void SpawnPlayer(GameObject playerObject)
    {
        Instantiate(playerObject, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

    /// <summary>
    /// Spawn enemies
    /// </summary>
    /// <param name="enemyObject"></param>
    /// <param name="point"></param>
    public void SpawnEnemy(GameObject enemyObject, LevelDataBase.EnemySpawnDetails spawnData)
    {
        EnemySpawnPointObjects spawnPoint = enemySpawnPoints.Find(pt => pt.Point == spawnData.SpawnPoint);
        if (spawnPoint != null)
        {
            GameObject obj = Instantiate(enemyObject, spawnPoint.PointObject.position, spawnPoint.PointObject.rotation);
            obj.GetComponent<MovementController>().SetNode(spawnData.DesgnatedPath);
        }
    }
}
