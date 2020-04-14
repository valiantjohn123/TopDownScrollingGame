using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missle control script
/// </summary>
public class SubMissile : BaseBullet
{
    private Transform targerEntity;
    private Vector2 previousPosition;

    /// <summary>
    /// Mono start
    /// </summary>
    private void Start()
    {
        if (FindEntity())
        {
            SoundHandler.PlaySound(Sounds.SoundType.Rocket);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Find an entity to attack
    /// </summary>
    /// <returns></returns>
    private bool FindEntity()
    {
        if (Type == Entity.EntityType.Enemy)
        {
            if (DependencyHolder.PlayerEntity != null)
                targerEntity = DependencyHolder.PlayerEntity.transform;
        }
        else
        {
            int index = Random.Range(0, DependencyHolder.Enemies.Count - 1);
            if (DependencyHolder.Enemies.Count > 0 && DependencyHolder.Enemies[index] != null)
                targerEntity = DependencyHolder.Enemies[index].transform;
        }

        return targerEntity != null;
    }

    /// <summary>
    /// On hit success
    /// </summary>
    public override void OnHit(Entity entity)
    {
        //Do nothing here
    }

    /// <summary>
    /// Mono update
    /// </summary>
    private void Update()
    {
        if (targerEntity == null)
        {
            Destroy(gameObject);
            return;
        }

        SetPositionAndRotation();

        Step += Time.deltaTime * Speed;
    }

    /// <summary>
    /// Set missile position and rotation
    /// </summary>
    private void SetPositionAndRotation()
    {
        Vector2 currentPos = transform.position;
        Vector2 direction = (currentPos - previousPosition).normalized;
        transform.up = direction;
        previousPosition = currentPos;
        Vector2 midPoint = new Vector2(Position.x, targerEntity.position.y);
        transform.position = Vector2.Lerp(Vector2.Lerp(Position, midPoint, Step), Vector2.Lerp(midPoint, targerEntity.position, Step), Step);
    }
}
