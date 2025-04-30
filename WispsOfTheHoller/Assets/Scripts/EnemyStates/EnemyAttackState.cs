using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttackState : BaseEnemyState
{
    [SerializeField]
    private float _attackTimeInSeconds = 1.625f;
    [SerializeField]
    private float _attackSize = 1.5f;
    [SerializeField]
    private float _attackDistance = 1;
    private bool _shouldTriggerChase = false;
    
    public override void EnterState()
    {
        _shouldTriggerChase = false;
        StartCoroutine(attackRoutine());
    }

    public override void FixedUpdateState()
    {
        RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, _attackSize, transform.forward, _attackDistance);
        for (int i = 0; i < attackHits.Length; i++)
        {
            if (attackHits[i].collider.tag == "Player")
            {
                LevelManager.ResetLevel();
            }
        }
    }

    public override ICharacterState GetNextState()
    {
        ICharacterState nextState = null;
        if (_shouldTriggerChase)
        {
            nextState = GetComponent<ChaseState>();
        }
        return nextState;
    }

    public override void UpdateState()
    {
    }

    private IEnumerator attackRoutine()
    {
        enemyContext.Animator.SetTrigger("Attack");
        yield return new WaitForSeconds(_attackTimeInSeconds);
        _shouldTriggerChase = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 start = transform.position;
        Vector3 end = transform.position + (transform.forward * _attackDistance);
        Gizmos.DrawWireSphere(start, _attackSize);
        Gizmos.DrawWireSphere(end, _attackSize);
    }
}
