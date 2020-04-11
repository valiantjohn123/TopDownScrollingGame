using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public MovementNodeBase Node
    {
        get 
        {
            return node;
        }
    }

    [SerializeField]
    private MovementNodeBase node;
    private ComponentHolder compHolder;

    /// <summary>
    /// Mono object awake
    /// </summary>
    private void Awake()
    {
        compHolder = ComponentHolder.GetHolder(gameObject);
        node.ResetNode();
    }

    /// <summary>
    /// Mono object update
    /// </summary>
    private void Update()
    {
        if (node != null && compHolder != null)
            node = node.Execute(compHolder.ObjectEntity);
    }
}
