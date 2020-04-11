﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds public references
/// </summary>
public abstract class DependencyHolder
{
    public static Entity PlayerEntity { get; set; }
    public static List<Entity> Enemies = new List<Entity>();
    public static StateController MainStateController;
}