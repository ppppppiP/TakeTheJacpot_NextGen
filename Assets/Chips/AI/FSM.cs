using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FSM
{
    private FsmState CurrentState { get; set; }
    private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();


    public void AddState(FsmState state)
    {
        _states.Add(state.GetType(), state);
    }

    public FsmState GetState()
    {
        return CurrentState;
    }

    public void SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            CurrentState?.Exit();

            CurrentState = newState;



            CurrentState.Enter();
        }
    }

    public void Update()
    {
        CurrentState.Update();
    }
}
