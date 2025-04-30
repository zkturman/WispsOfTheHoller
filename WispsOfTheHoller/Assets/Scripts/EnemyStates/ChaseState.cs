using UnityEngine;

public class ChaseState : BaseEnemyState
{
    [SerializeField]
    private float _attackTriggerDistance = 2;
    private bool _shouldTriggerAttack = false;

    public override void EnterState()
    {
        _shouldTriggerAttack = false;
        enemyContext.Model.SetActive(true);
    }

    public override void FixedUpdateState()
    {
        enemyContext.Body.linearVelocity = transform.forward * enemyContext.Stats.Speed;
    }

    public override ICharacterState GetNextState()
    {
        ICharacterState nextState = null;
        if (_shouldTriggerAttack)
        {
            nextState = GetComponent<EnemyAttackState>();
        }
        return nextState;
    }

    public override void UpdateState()
    {
        if (enemyContext.FollowObject != null)
        {
            enemyContext.Parent.transform.LookAt(enemyContext.FollowObject.transform, Vector3.up);
            float distance = Vector3.Distance(transform.position, enemyContext.FollowObject.transform.position);
            if (distance < _attackTriggerDistance)
            {
                _shouldTriggerAttack = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + (transform.forward * _attackTriggerDistance);
        Gizmos.DrawLine(start, end);
    }
}
