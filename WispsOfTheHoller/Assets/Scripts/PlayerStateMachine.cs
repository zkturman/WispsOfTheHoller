using UnityEngine;

public class PlayerStateMachine: MonoBehaviour
{
    [SerializeField]
    private PlayerContext context;
    private IPlayerState currentState;
    [SerializeField]
    private string defaultStateKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IPlayerState[] playerStates = GetComponents<IPlayerState>();
        for (int i = 0; i < playerStates.Length; i++)
        {
            playerStates[i].InitialiseState(context);
            if (playerStates[i].Key.Equals(defaultStateKey, System.StringComparison.InvariantCultureIgnoreCase))
            {
                currentState = playerStates[i];
            }
        }
        if (currentState != null)
        {
            currentState.EnterState();
        }
    }

    private void Update()
    {
        IPlayerState nextState = currentState.GetNextState();
        if (currentState.GetNextState() != null)
        {
            currentState = nextState;
            currentState.EnterState();
        }
        currentState.UpdateState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            (currentState as BaseState).LateUpdateState();
        }
    }
}
