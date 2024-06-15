public abstract class FsmState
{
    protected readonly FSM fsm;


    public FsmState(FSM fsm)
    {
        this.fsm = fsm;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();


}
