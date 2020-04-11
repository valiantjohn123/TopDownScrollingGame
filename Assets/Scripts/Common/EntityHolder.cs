using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityHolder
{
    public static Entity PlayerEntity { get; set; }
    public static List<Entity> Enemies = new List<Entity>();
}
