using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum States 
    {
        NullState, Menu, Game, GameWin, GameFailed
    }

    public static Dictionary<States, State> AvailableStates 
    {
        get;
        private set;
    }
    public static State CurrentState;

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
    /// Change current state
    /// </summary>
    /// <param name="stateID"></param>
    /// <param name="setBackState"></param>
    public static void ChangeState(States stateID, bool setBackState = false)
    {
        if (!AvailableStates.ContainsKey(stateID))
        {
            return;
        }

        CurrentState?.UnloadState();
        State nextState = AvailableStates[stateID];
        if (setBackState && CurrentState.StateID != States.NullState)
            nextState.BackID = CurrentState.StateID;
        CurrentState = nextState;
        CurrentState.LoadState();
    }

    /// <summary>
    /// Close current state
    /// </summary>
    public static void CloseState()
    {
        if (CurrentState != null && CurrentState.BackID != States.NullState)
        {
            ChangeState(CurrentState.BackID, false);
        }
    }
}
