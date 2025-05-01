using UnityEngine;

public class CharacterStateMachine: MonoBehaviour
{
    [SerializeField]
    private CharacterContext context;
    private ICharacterState currentState;
    [SerializeField]
    private string defaultStateKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ICharacterState[] characterStates = GetComponents<ICharacterState>();
        for (int i = 0; i < characterStates.Length; i++)
        {
            characterStates[i].InitialiseState(context);
            if (characterStates[i].Key.Equals(defaultStateKey, System.StringComparison.InvariantCultureIgnoreCase))
            {
                currentState = characterStates[i];
            }
        }
        if (currentState != null)
        {
            currentState.EnterState();
        }
    }

    private void Update()
    {
        ICharacterState nextState = currentState.GetNextState();
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
        if (currentState != null && currentState is BaseState)
        {
            (currentState as BaseState).LateUpdateState();
        }
    }
}
