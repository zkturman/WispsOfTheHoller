using UnityEngine;

public class MoveState : BaseState
{
    public override IPlayerState GetNextState()
    {
        IPlayerState nextState = null;
        if (playerContext.InputHandler.Dash)
        {
            nextState = GetComponent<SprintState>();
        }
        else if (playerContext.InputHandler.Attack)
        {
            nextState = GetComponent<AttackState>();
        }
        else if (playerContext.InputHandler.Movement == Vector2.zero)
        {
            nextState = GetComponent<IdleState>();
        }
        return nextState;
    }

    public override void InitialiseState(PlayerContext context)
    {
        playerContext = context;
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        playerContext.Model.transform.rotation = Quaternion.LookRotation(playerContext.Body.linearVelocity, playerContext.Model.transform.up);
    }

    public override void FixedUpdateState()
    {
        Vector2 playerVelocity = playerContext.InputHandler.Movement * playerContext.Stats.Speed;
        playerContext.Body.linearVelocity = playerContext.CameraRoot.transform.rotation * 
            new Vector3(playerVelocity.x, playerContext.Body.linearVelocity.y, playerVelocity.y);
    }
}
