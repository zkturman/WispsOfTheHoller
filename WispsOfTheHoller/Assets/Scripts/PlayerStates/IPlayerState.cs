using UnityEngine;

public interface IPlayerState
{
    public string Key { get; }
    public void InitialiseState(PlayerContext context);
    public IPlayerState GetNextState();

    public void EnterState();
    public void UpdateState();

    public void FixedUpdateState();
}
