﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game state controller, this controls game states. States control UI 
/// </summary>
public class StateController : MonoBehaviour
{
    public enum States 
    {
        NullState, Menu, Game, GameWin, GameFailed, PauseState
    }

    public Dictionary<States, State> AvailableStates 
    {
        get;
        private set;
    }
    public State CurrentState;
    
    /// <summary>
    /// Triggers on state changed
    /// </summary>
    public Action<State, State> OnStateChanged;

    [SerializeField]
    private States defaultState;
    [SerializeField]
    private List<State> availableStates;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        AvailableStates = new Dictionary<States, State>();
        availableStates.ForEach(item => 
        {
            if (!AvailableStates.ContainsKey(item.StateID))
                AvailableStates.Add(item.StateID, item);
        });
        DependencyHolder.MainStateController = this;
    }

    /// <summary>
    /// Mono start
    /// </summary>
    private void Start()
    {
        ChangeState(defaultState, false);
    }

    /// <summary>
    /// Mono update
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseState();
        }
    }

    /// <summary>
    /// Change current state
    /// </summary>
    /// <param name="stateID"></param>
    /// <param name="setBackState"></param>
    public void ChangeState(States stateID, bool setBackState = false)
    {
        if (!AvailableStates.ContainsKey(stateID))
        {
            return;
        }

        CurrentState?.UnloadState();
        State nextState = AvailableStates[stateID];
        if (setBackState && CurrentState.StateID != States.NullState)
            nextState.BackID = CurrentState.StateID;

        var prevState = CurrentState;
        CurrentState = nextState;
        CurrentState.LoadState();
        OnStateChanged?.Invoke(prevState, nextState);
    }

    /// <summary>
    /// Close current state
    /// </summary>
    public void CloseState()
    {
        if (CurrentState != null && CurrentState.BackID != States.NullState)
        {
            ChangeState(CurrentState.BackID, false);
        }
    }
}
