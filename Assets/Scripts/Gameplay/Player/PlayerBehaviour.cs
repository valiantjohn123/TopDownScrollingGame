using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private MovementNodeBase exitNode;

    private ComponentHolder holder;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        holder = ComponentHolder.GetHolder(gameObject);
    }

    /// <summary>
    /// Mono start
    /// </summary>
    private void Start()
    {
        DependencyHolder.MainStateController.OnStateChanged += OnStateChanged;
    }

    private void OnStateChanged(State from, State current)
    {
        if (current.StateID == StateController.States.GameWin)
        {
            holder.MovementController.SetNode(exitNode);
        }
    }

    /// <summary>
    /// On object destroyed
    /// </summary>
    private void OnDestroy()
    {
        DependencyHolder.MainStateController.OnStateChanged -= OnStateChanged;
    }
}
