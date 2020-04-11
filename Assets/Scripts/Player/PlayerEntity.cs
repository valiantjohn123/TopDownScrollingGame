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
        EntityHolder.PlayerEntity = this;
    }

    /// <summary>
    /// Execute on player dies
    /// </summary>
    public override void OnDeath()
    {
        EntityHolder.PlayerEntity = null;
    }
}
