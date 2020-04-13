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
        public Path.Paths PathName;
        public MovementNodeBase DesgnatedPath;
    }
    #endregion

    /// <summary>
    /// Path Data
    /// </summary>
    public Path PathData;

    /// <summary>
    /// List of spawn data
    /// </summary>
    public List<EnemySpawnDetails> LevelSpawnList;

    /// <summary>
    /// Populates the needed data
    /// </summary>
    [ContextMenu("Populate Data")]
    private void GenerateData()
    {
        for (int i = 0; i < LevelSpawnList.Count; i++)
        {
            LevelSpawnList[i].DesgnatedPath = PathData.PathsList.Find(pt => pt.PathName == LevelSpawnList[i].PathName).FirstNode;
        }
    }
}
