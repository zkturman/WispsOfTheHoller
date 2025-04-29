using UnityEngine;

public abstract class BaseEnemyState : MonoBehaviour, ICharacterState
{
    protected EnemyContext enemyContext;
    [SerializeField]
    private string key = "Idle";
    public string Key { get => key; }

    public abstract void EnterState();

    public abstract ICharacterState GetNextState();

    public virtual void InitialiseState(CharacterContext context)
    {
        enemyContext = context as EnemyContext;
    }

    public abstract void UpdateState();

    public abstract void FixedUpdateState();
}