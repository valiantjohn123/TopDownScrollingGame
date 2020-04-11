using System;

/// <summary>
/// Player entity
/// </summary>
public class EnemyEntity : Entity
{
    /// <summary>
    /// Mono object awake
    /// </summary>
    private void Awake()
    {
        if (!EntityHolder.Enemies.Contains(this))
            EntityHolder.Enemies.Add(this);
    }

    /// <summary>
    /// Execute on player dies
    /// </summary>
    public override void OnDeath()
    {
        EntityHolder.Enemies.Remove(this);
    }
}
