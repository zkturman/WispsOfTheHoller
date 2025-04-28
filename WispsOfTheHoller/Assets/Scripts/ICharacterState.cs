using UnityEngine;

public interface ICharacterState
{
    public string Key { get; }
    public void InitialiseState(CharacterContext context);
    public ICharacterState GetNextState();

    public void EnterState();
    public void UpdateState();

    public void FixedUpdateState();
}
