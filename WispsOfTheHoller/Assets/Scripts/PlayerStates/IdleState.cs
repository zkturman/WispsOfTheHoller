using UnityEngine;

public class IdleState : BaseState
{
    [SerializeField]
    private string animationTrigger = "Neutral";
    public override ICharacterState GetNextState()
    {
        ICharacterState nextState = null;
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
        else
        {
            playerContext.InputHandler.Attack = false;
            playerContext.InputHandler.Dash = false;
        }
        return nextState;
    }

    public override void EnterState()
    {
        playerContext.Body.linearVelocity = Vector2.zero;
        playerContext.Animator.SetTrigger(animationTrigger);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
