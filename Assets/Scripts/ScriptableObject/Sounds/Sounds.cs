using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data structure for holding sounds
/// </summary>
[CreateAssetMenu(fileName = "SoundsData", menuName = "Sounds/MainData", order = 1)]
public class Sounds : ScriptableObject
{
    #region Helper classes
    public enum SoundType
    {
        BasicGunPlayer, BasicGunEnemy, Rocket, Explosion, BG, ExplosionMedium, ExplosionHuge
    }

    [System.Serializable]
    public class SoundData
    {
        public SoundType Type;
        public AudioClip SoundClip;
        [System.NonSerialized]
        public AudioSource Source;
    }
    #endregion

    public List<SoundData> AudioClips;
}
