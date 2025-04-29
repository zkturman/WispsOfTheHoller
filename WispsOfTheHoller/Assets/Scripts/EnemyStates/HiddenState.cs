using UnityEngine;

public class HiddenState : BaseEnemyState
{
    private bool _playerWithinBoundary = false;
    public override void EnterState()
    {
        _playerWithinBoundary = false;
        enemyContext.Model.gameObject.SetActive(false);
    }

    public override void FixedUpdateState()
    {
    }

    public override ICharacterState GetNextState()
    {
        ICharacterState nextState = null;
        if (_playerWithinBoundary)
        {
            nextState = GetComponent<ChaseState>();
        }
        return nextState;
    }

    public override void UpdateState()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerWithinBoundary = true;
            enemyContext.Player = other.gameObject;
        }
    }
}
