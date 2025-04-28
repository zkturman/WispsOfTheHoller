using UnityEngine;

public abstract class BaseState : MonoBehaviour, ICharacterState
{
    protected PlayerContext playerContext;
    [SerializeField]
    private string key = "Idle";
    public string Key { get => key; }

    public abstract void EnterState();

    public abstract ICharacterState GetNextState();

    public virtual void InitialiseState(CharacterContext context)
    {
        playerContext = context as PlayerContext;
    }

    public abstract void UpdateState();

    public abstract void FixedUpdateState();

    public virtual void LateUpdateState()
    {
        if (playerContext.InputHandler.Look != Vector2.zero)
        {
            float rotation = playerContext.InputHandler.Look.x * playerContext.Stats.RotationSpeed;
            playerContext.CameraRoot.transform.Rotate(new Vector3(0, rotation, 0));
        }
    }
}
