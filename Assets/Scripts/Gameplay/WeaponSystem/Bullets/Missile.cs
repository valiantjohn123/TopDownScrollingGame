using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missle control script
/// </summary>
public class Missile : BaseBullet
{
    [SerializeField]
    private float effectRadius = 1f;
    
    /// <summary>
    /// Mono start
    /// </summary>
    private void Start()
    {
        SoundHandler.PlaySound(Sounds.SoundType.Rocket);
    }

    /// <summary>
    /// On hit success
    /// </summary>
    public override void OnHit(Entity entity)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, effectRadius);
        for(int i=0; i < enemies.Length; i++)
        {
            Entity ent = enemies[i].GetComponent<Entity>();
            if (ent != null && ent.Type != Type)
            {
                ent.TakeDamage(Damage);
            }
        }
    }

    /// <summary>
    /// Mono update
    /// </summary>
    private void Update()
    {
        transform.position = Vector2.Lerp(Position, Position + (Direction * Range), Step);

        Step += Time.deltaTime * Speed;
    }
}
