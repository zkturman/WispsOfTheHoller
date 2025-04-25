using UnityEngine;

public class IdleState : BaseState
{

    public override IPlayerState GetNextState()
    {
        IPlayerState nextState = null;
        if (playerContext.InputHandler.Dash && playerContext.Controller.HasMana())
        {
            nextState = GetComponent<SprintState>();
        }
        else if (playerContext.InputHandler.Attack && playerContext.Controller.HasMana())
        {
            nextState = GetComponent<AttackState>();
        }
        else if (playerContext.InputHandler.Movement != Vector2.zero)
        {
            nextState = GetComponent<MoveState>();
        }
        return nextState;
    }

    public override void EnterState()
    {
        playerContext.Body.linearVelocity = Vector2.zero;
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
