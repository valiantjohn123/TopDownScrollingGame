using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component holder helper
/// </summary>
public class ComponentHolder : MonoBehaviour
{
    public Entity ObjectEntity 
    {
        get
        { 
            return objectEntity;
        }
    }
    public MovementController MovementController
    {
        get
        {
            return movementController;
        }
    }
    public Camera MainCamera 
    {
        get; 
        private set; 
    }
    public WeaponsController WeaponsController
    {
        get
        {
            return weaponsController;
        }
    }
    public GameObject CollisionListner
    {
        get
        {
            return collisionListner;
        }
    }

    [SerializeField]
    private Entity objectEntity;
    [SerializeField]
    private MovementController movementController;
    [SerializeField]
    private WeaponsController weaponsController;
    [SerializeField]
    private GameObject collisionListner;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        MainCamera = Camera.main;
    }

    /// <summary>
    /// Get the holder
    /// </summary>
    /// <param name="gmObject"></param>
    /// <returns></returns>
    public static ComponentHolder GetHolder(GameObject gmObject)
    {
        ComponentHolder compHolder = gmObject.GetComponent<ComponentHolder>();
        if (compHolder == null)
        {
            Destroy(gmObject);
            return null;
        }
        else
        {
            return compHolder;
        }
    }
}
