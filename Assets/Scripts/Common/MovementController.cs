using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private MovementNodeBase node;

    private ComponentHolder compHolder;

    private void Awake()
    {
        compHolder = GetComponent<ComponentHolder>();
        if (compHolder == null)
            Destroy(gameObject);

        node.ResetNode();
    }

    private void Update()
    {
        if (node != null && compHolder != null)
            node = node.Execute(compHolder.ObjectEntity);
    }
}
