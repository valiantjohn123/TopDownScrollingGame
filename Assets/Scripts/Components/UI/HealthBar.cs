using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Entity entity;
    [SerializeField]
    private Entity.EntityType type;

    private Image image;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        if (entity == null)
        {
            if (type == Entity.EntityType.Player)
                entity = DependencyHolder.PlayerEntity;
        }

        image = GetComponent<Image>();
        entity.HealthUpdated += OnHealthChanged;
    }

    /// <summary>
    /// On health changed
    /// </summary>
    /// <param name="obj"></param>
    private void OnHealthChanged(float percentage)
    {
        image.fillAmount = percentage;
    }

    /// <summary>
    /// Mono on destroy
    /// </summary>
    private void OnDestroy()
    {
        entity.HealthUpdated -= OnHealthChanged;
    }
}
