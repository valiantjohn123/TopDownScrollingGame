using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler that handles sounds
/// </summary>
public class SoundHandler : MonoBehaviour
{
    [SerializeField]
    private Sounds sounds;

    private static Sounds allSounds;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        allSounds = sounds;

        for (int i = 0; i < allSounds.AudioClips.Count; i++)
        {
            allSounds.AudioClips[i].Source = gameObject.AddComponent<AudioSource>();
            allSounds.AudioClips[i].Source.clip = allSounds.AudioClips[i].SoundClip;
        }

        PlaySound(Sounds.SoundType.BG, true);
    }

    /// <summary>
    /// Play a small sound
    /// </summary>
    /// <param name="type"></param>
    public static void PlaySound(Sounds.SoundType type, bool loop = false)
    {
        var source = allSounds.AudioClips.Find(cl => cl.Type == type)?.Source;
        source.loop = loop;
        source.Play();
    }

    /// <summary>
    /// Stop playing sound
    /// </summary>
    /// <param name="type"></param>
    public static void StopSound(Sounds.SoundType type)
    {
        var source = allSounds.AudioClips.Find(cl => cl.Type == type)?.Source;
        source.Stop();
    }

    /// <summary>
    /// Mono destroyed
    /// </summary>
    private void OnDestroy()
    {
        StopSound(Sounds.SoundType.BG);
    }
}
