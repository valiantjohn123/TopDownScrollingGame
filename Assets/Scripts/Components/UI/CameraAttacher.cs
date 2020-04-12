using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CameraAttacher : MonoBehaviour
{
    [SerializeField]
    private ComponentHolder holder;

    /// <summary>
    /// Mono start
    /// </summary>
    private void Start()
    {
        GetComponent<Canvas>().worldCamera = holder.MainCamera;
    }
}
