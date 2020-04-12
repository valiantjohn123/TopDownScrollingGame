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

    public static Action<int> EnemiesCountChanged;

    /// <summary>
    /// Mono object awake
    /// </summary>
    private void Awake()
    {
        if (!DependencyHolder.Enemies.Contains(this))
            DependencyHolder.Enemies.Add(this);

        EnemiesCountChanged?.Invoke(DependencyHolder.Enemies.Count);
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
        if (DependencyHolder.Enemies != null)
            DependencyHolder.Enemies.Remove(this);

        EnemiesCountChanged?.Invoke(DependencyHolder.Enemies.Count);
    }
}
