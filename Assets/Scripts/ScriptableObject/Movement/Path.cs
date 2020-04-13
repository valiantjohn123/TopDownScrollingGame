using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Paths", menuName = "Movement/Paths", order = 1)]
/// <summary>
/// Data structure of paths
/// </summary>
public class Path : ScriptableObject
{
    #region Classes
    public enum Paths
    {
        MoveForwardStep, MoveToCenter, MoveToP1, MoveToP2, MoveToP4, MoveToP5, MoveSideToSide
    }

    [System.Serializable]
    public class PathData
    {
        public Paths PathName;
        public MovementNodeBase FirstNode;
    }
    #endregion

    public List<PathData> PathsList;
}
