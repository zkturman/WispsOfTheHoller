using UnityEngine;
using UnityEngine.VFX;

public class AttackState : BaseState
{
    [SerializeField]
    private float attackTimeInSeconds = 1.5f;
    private float secondsInState = 0f;
    [SerializeField]
    private float attackDistance = 3f;
    [SerializeField]
    private VisualEffect screamEffect;
    [SerializeField]
    private AudioClip screamSound;
    public override void EnterState()
    {
        playerContext.InputHandler.Attack = false;
        secondsInState = 0f;
        playerContext.Body.linearVelocity = Vector3.zero;
        playerContext.Controller.UseMana(playerContext.Stats.ScreamRequiredMana);
        screamEffect.Play();
        if (screamSound != null)
        {
            playerContext.AudioSource.PlayOneShot(screamSound);
        }
    }

    public override void FixedUpdateState()
    {
        if (Physics.Raycast(playerContext.Model.transform.position, playerContext.Model.transform.forward, out RaycastHit hitInfo, attackDistance))
        {
            if (hitInfo.collider.TryGetComponent(out PuzzleTarget target))
            {
                target.Solve();
            }
        }
    }

    public override ICharacterState GetNextState()
    { 
        ICharacterState nextState = null;
        if (secondsInState > attackTimeInSeconds)
        {
            nextState = GetComponent<IdleState>();
        }
        return nextState;
    }

    public override void UpdateState()
    {
        secondsInState += Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (playerContext != null)
        {
            Gizmos.DrawSphere(playerContext.Model.transform.position, 1f);
            Gizmos.DrawLine(playerContext.Model.transform.position, playerContext.Model.transform.position + (playerContext.Model.transform.forward * attackDistance));
        }
    }
}
