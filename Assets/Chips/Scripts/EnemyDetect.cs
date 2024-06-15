using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.UI;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField] float m_detectTime;
    [SerializeField] NavMeshAgent m_agent;
    [SerializeField] Transform[] m_targets;
    public event Action EOnPlayerDetected;

    private FSM _fsm;
    private bool _isEnter;

    private void Start()
    {
        _fsm = new FSM();
        _fsm.AddState(new FsmStateIdle(_fsm, m_agent, m_detectTime, EOnPlayerDetected));
        _fsm.AddState(new FsmStateMove(_fsm, m_agent, m_targets, EOnPlayerDetected));
        _fsm.SetState<FsmStateIdle>();
        if (_isEnter)
        {
            EOnPlayerDetected?.Invoke();
        }
    }

    public void Update()
    {
        _fsm.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
            _isEnter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
            _isEnter = false;
        }
    }
}
