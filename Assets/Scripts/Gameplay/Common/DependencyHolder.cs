using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds public references
/// </summary>
public abstract class DependencyHolder
{
    public static Entity PlayerEntity { get; set; }
    public static StateController MainStateController { get; set; }
    public static List<Entity> Enemies { get; set; }
    public static List<BackGroundScroller> BackgroundScrollers = new List<BackGroundScroller>();
}
