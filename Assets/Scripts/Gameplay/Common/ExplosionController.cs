using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Auto Destroy the object after certain amount of time
/// </summary>
public class ExplosionController : MonoBehaviour
{
    [SerializeField]
    private float delay = 2f;

    /// <summary>
    /// Mono start
    /// </summary>
    void Start()
    {
        SoundHandler.PlaySound(Sounds.SoundType.Explosion);
        Destroy(gameObject, delay);
    }
}
