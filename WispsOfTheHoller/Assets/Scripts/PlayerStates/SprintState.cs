using UnityEngine;

public class SprintState : BaseState
{
    [SerializeField]
    private float secondsOfDash = 1f;
    private float secondsInState = 0f;

    public override void EnterState()
    {
        playerContext.InputHandler.Dash = false;
        secondsInState = 0f;
        playerContext.Body.linearVelocity = playerContext.Stats.DashSpeed * playerContext.ParentObject.transform.forward;
    }

    public override void FixedUpdateState()
    {
        playerContext.Body.linearVelocity = Mathf.Lerp(playerContext.Stats.DashSpeed, playerContext.Stats.Speed, (secondsInState / secondsOfDash)) 
            * playerContext.Model.transform.forward;
    }

    public override IPlayerState GetNextState()
    {
        IPlayerState nextState = null;
        if (secondsInState > secondsOfDash)
        {
            nextState = GetComponent<IdleState>();
        }
        return nextState;
    }

    public override void UpdateState()
    {
        secondsInState += Time.deltaTime;
    }

    public override void LateUpdateState()
    {
    }
}
