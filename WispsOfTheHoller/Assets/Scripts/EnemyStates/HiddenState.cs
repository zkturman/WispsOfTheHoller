using UnityEngine;

public class HiddenState : BaseEnemyState
{
    [SerializeField]
    private float _chaseDistance = 8;
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
        if (_playerWithinBoundary || enemyContext.Timer.TimeIsExpired)
        {
            nextState = GetComponent<ChaseState>();
        }
        return nextState;
    }

    public override void UpdateState()
    {
        enemyContext.Parent.transform.LookAt(enemyContext.FollowObject.transform);
        float playerDistance = Vector3.Distance(transform.position, enemyContext.FollowObject.transform.position);
        if (playerDistance < _chaseDistance)
        {
            _playerWithinBoundary = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 start = transform.position;
        Vector3 end = transform.position + (transform.forward * _chaseDistance);
        Gizmos.DrawLine(start, end);
    }
}
