using System.Collections;
using UnityEngine;

public class ChaseState : BaseEnemyState
{
    [SerializeField]
    private float _attackTriggerDistance = 2;
    [SerializeField]
    private float _chaseDelayInSeconds = 1;
    private bool _allowedToAttack = false;
    private bool _shouldTriggerAttack = false;

    public override void EnterState()
    {
        _allowedToAttack = false;
        _shouldTriggerAttack = false;
        enemyContext.Model.SetActive(true);
        StartCoroutine(waitRoutine());
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
            if (distance < _attackTriggerDistance && _allowedToAttack)
            {
                _shouldTriggerAttack = true;
            }
        }
    }

    private IEnumerator waitRoutine()
    {
        yield return new WaitForSeconds(_chaseDelayInSeconds);
        _allowedToAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + (transform.forward * _attackTriggerDistance);
        Gizmos.DrawLine(start, end);
    }
}
