using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level data scriptable object
/// </summary>
[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData/BaseData", order = 1)]
public class LevelDataBase : ScriptableObject
{
    #region Helper classes
    [System.Serializable]
    public class EnemySpawnDetails
    {
        [System.NonSerialized]
        public bool IsSpawned;
        public float InTime;
        public EnemyEntity.EnemyType Type;
        public ObjectSpawner.EnemySpawnPoints SpawnPoint;
        public MovementNodeBase DesgnatedPath;
    }
    #endregion

    /// <summary>
    /// List of spawn data
    /// </summary>
    public List<EnemySpawnDetails> LevelSpawnList;
}
