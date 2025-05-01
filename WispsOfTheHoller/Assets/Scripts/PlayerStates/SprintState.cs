using UnityEngine;
using UnityEngine.VFX;

public class SprintState : BaseState
{
    [SerializeField]
    private float secondsOfDash = 1f;
    private float secondsInState = 0f;
    [SerializeField]
    private VisualEffect dashEffect;
    [SerializeField]
    private AudioClip dashSound;

    public override void EnterState()
    {
        playerContext.InputHandler.Dash = false;
        secondsInState = 0f;
        playerContext.Body.linearVelocity = playerContext.Stats.DashSpeed * playerContext.ParentObject.transform.forward;
        playerContext.Controller.UseMana(playerContext.Stats.DashRequiredMana);
        dashEffect.Play();
        if (dashSound != null)
        {
            playerContext.AudioSource.PlayOneShot(dashSound);
        }
    }

    public override void FixedUpdateState()
    {
        playerContext.Body.linearVelocity = Mathf.Lerp(playerContext.Stats.DashSpeed, playerContext.Stats.Speed, (secondsInState / secondsOfDash)) 
            * playerContext.Model.transform.forward;
    }

    public override ICharacterState GetNextState()
    {
        ICharacterState nextState = null;
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
