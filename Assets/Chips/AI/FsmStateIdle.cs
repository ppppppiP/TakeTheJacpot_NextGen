using UnityEngine.AI;
using UnityEngine;
using System;

public class FsmStateIdle : FsmState
{
    private NavMeshAgent _agent;

    private float _timer;
    private float _maxTime;
    private Action EOnPlayerDetected;
    public FsmStateIdle(FSM fsm, NavMeshAgent agent, float time, Action OnPlayerDetected) : base(fsm)
    {
        _agent = agent;
        _maxTime = time;   
        EOnPlayerDetected = OnPlayerDetected;
    }

    public override void Enter()
    {
        Debug.Log("Idle");
        _timer = 0f;
    }

    public override void Exit()
    {
        _timer = 0f;
    }

    public override void Update()
    {
        EOnPlayerDetected?.Invoke();
        _timer += Time.deltaTime;
        
        if(_timer > _maxTime)
        {
            fsm.SetState<FsmStateMove>();
        }
    }
}
public class FsmStateMove : FsmState
{
    private NavMeshAgent _agent;
    private Transform[] _targets;
    int _index = 0;
    Action EOnIndexChange;
    Action EOnPlayerDetected;
    public FsmStateMove(FSM fsm, NavMeshAgent agent, Transform[] targets, Action eOnPlayerDetected) : base(fsm)
    {
        _agent = agent;
        _targets = targets;
        EOnPlayerDetected = eOnPlayerDetected;
    }

    public override void Enter()
    {   
        if(_index == (_targets.Length - 1))
        {
            EOnIndexChange += SubstractIndex;
            EOnIndexChange -= AddIndex;
        }
        else if(_index == 0)
        {
            EOnIndexChange -= SubstractIndex;
            EOnIndexChange += AddIndex;
        }
        EOnPlayerDetected?.Invoke();
        Debug.Log(_index);
        _agent.SetDestination(_targets[_index].position);
        
        
    }

    public override void Exit()
    {
        EOnIndexChange?.Invoke();
       // EOnIndexChange = null;
    }

    private void AddIndex()
    {
        _index++;
    }

    private void SubstractIndex()
    {
        _index--;
    }

    public override void Update()
    {
        if (_agent.path.status == NavMeshPathStatus.PathComplete)
        {
            Debug.Log("agent finish");
            fsm.SetState<FsmStateIdle>();
        }
    }
}

public class FsmStateAttack: FsmState
{
    private NavMeshAgent _agent;
    private Transform _target;

    public FsmStateAttack(FSM fsm) : base(fsm)
    {
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}