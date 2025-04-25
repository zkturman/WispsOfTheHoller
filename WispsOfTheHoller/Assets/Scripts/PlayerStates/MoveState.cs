using UnityEngine;

public class MoveState : BaseState
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
        Vector2 unit = playerContext.InputHandler.Movement.normalized;
        float angleInRadians = Mathf.Atan2(unit.x, unit.y); // Get the angle in radians
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;
        playerContext.Model.transform.rotation = playerContext.CameraRoot.transform.rotation;
        playerContext.Model.transform.Rotate(0, angleInDegrees, 0);
    }

    public override void FixedUpdateState()
    {
        Vector2 playerVelocity = playerContext.InputHandler.Movement * playerContext.Stats.Speed;
        playerContext.Body.linearVelocity = playerContext.CameraRoot.transform.rotation * 
            new Vector3(playerVelocity.x, playerContext.Body.linearVelocity.y, playerVelocity.y);
    }
}
