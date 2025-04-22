using UnityEngine;

public abstract class BaseState : MonoBehaviour, IPlayerState
{
    protected PlayerContext playerContext;
    [SerializeField]
    private string key = "Idle";
    public string Key { get => key; }

    public abstract void EnterState();

    public abstract IPlayerState GetNextState();

    public virtual void InitialiseState(PlayerContext context)
    {
        playerContext = context;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
