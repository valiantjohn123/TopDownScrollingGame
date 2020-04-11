using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy behaviour controller
/// </summary>
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float readyTime = 2f;

    private ComponentHolder holder;
    private float timer;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
    }

    /// <summary>
    /// Mono update
    /// </summary>
    void Update()
    {
        if (timer >= readyTime)
        {
            if (holder.WeaponsController != null)
                holder.WeaponsController.FirePrimaryWeapons();
        }

        timer += Time.deltaTime;
    }
}
