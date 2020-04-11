using System;

/// <summary>
/// Player entity
/// </summary>
public class PlayerEntity : Entity
{
    /// <summary>
    /// Mono object awake
    /// </summary>
    private void Awake()
    {
        DependencyHolder.PlayerEntity = this;
    }

    /// <summary>
    /// Execute on player dies
    /// </summary>
    public override void OnDeath()
    {
        DependencyHolder.PlayerEntity = null;
    }
}
