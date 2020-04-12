using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroller : MonoBehaviour
{
    public static float multiplier = 1;

    [SerializeField]
    private float speed;

    private RawImage image;
    private float position;
    private Rect imageRect;

    /// <summary>
    /// Mono on awake
    /// </summary>
    private void Awake()
    {
        image = GetComponent<RawImage>();
        imageRect = image.uvRect;
        DependencyHolder.BackgroundScrollers.Add(this);
    }

    /// <summary>
    /// Mono on update
    /// </summary>
    private void Update()
    {
        position += Time.deltaTime * speed * multiplier;

        imageRect.y = position;
        image.uvRect = imageRect;
    }

    /// <summary>
    /// Mono on destroy
    /// </summary>
    private void OnDestroy()
    {
        DependencyHolder.BackgroundScrollers.Remove(this);
        multiplier = 1;
    }
}
