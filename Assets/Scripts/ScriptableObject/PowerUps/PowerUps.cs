using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base data structure of powerups
/// </summary>
[CreateAssetMenu(fileName = "PowerUpsData", menuName = "PowerUps/BaseData", order = 1)]
public class PowerUps : ScriptableObject
{
    #region Helper data
    public enum PowerUpType
    {
        Shield, Missile
    }

    [System.Serializable]
    public class PowerUpData
    {
        public PowerUpType Type;
        public float ChargeTime;
        public float ExpireTime;
    }
    #endregion

    public List<PowerUpData> PowerUpsList;
}
