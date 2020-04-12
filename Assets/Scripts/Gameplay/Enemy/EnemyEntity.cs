using System;
using UnityEngine;

/// <summary>
/// Player entity
/// </summary>
public class EnemyEntity : Entity
{
    public enum EnemyType
    {
        Small, Medium, Boss
    }

    public EnemyType EnemyTypeEnum;

    [SerializeField]
    private int score = 1;

    /// <summary>
    /// Mono object awake
    /// </summary>
    private void Awake()
    {
        if (!DependencyHolder.Enemies.Contains(this))
            DependencyHolder.Enemies.Add(this);
    }

    /// <summary>
    /// Execute on player dies
    /// </summary>
    public override void OnDeath()
    {
        Global.CurrentGame.Score += score;
        Destroy(gameObject);
    }

    /// <summary>
    /// On mono destroyed
    /// </summary>
    private void OnDestroy()
    {
        DependencyHolder.Enemies.Remove(this);
    }
}
