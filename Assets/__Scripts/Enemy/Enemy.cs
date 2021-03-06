using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Enemy : NetworkBehaviour
{
    [SerializeField] protected EnemyStats stats;
    [SerializeField] private GameObject enemyHealthBar;

    [SerializeField] protected GameObject currentTarget;

    [SerializeField] private GameObject testArm;

    [SyncVar]
    protected EnemyState currentState;

    [SyncVar(hook = nameof(OnHealthChanged))]
    protected float currentHealth;

    protected NavMeshAgent agent;
    private bool isAttacking = false;

    public EnemyState CurrentState { get { return currentState; } set { currentState = value; } }

    public override void OnStartServer()
    {
        base.OnStartServer();
        currentHealth = stats.MaxHealth;
        currentState = EnemyState.SetTarget;
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("CheckState", 1f, .1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void Attack()
    {
        if (!isAttacking)
        {
            agent.isStopped = true;
            isAttacking = true;

            testArm.SetActive(true);

            var tween = testArm.transform.DOLocalRotate(new Vector3(0, -90f), .5f);

            tween.OnComplete(() => ChangeState(EnemyState.BetweenAttacks));
            tween.OnComplete(() => isAttacking = false);
            tween.OnComplete(() => testArm.SetActive(false));
        }
    }

    [Server]
    void CheckState()
    {
        switch (currentState)
        {
            case EnemyState.SetTarget:
                SetBaseTarget();
                Debug.Log(currentState);
                break;
            case EnemyState.MoveToTargetPosition:
                CheckIfInAttackRange();
                MoveTowardsCurrentTarget();
                Debug.Log(currentState);
                break;
            case EnemyState.CheckForCloserTarget:
                CheckForOtherTargetsInRange();
                Debug.Log(currentState);
                break;
            case EnemyState.AttackTarget:
                Attack();
                break;
            case EnemyState.BetweenAttacks:
                Debug.Log(currentState);
                break;
            default:
                break;
        }
    }

    private void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    protected void CheckIfInAttackRange()
    {
        if(Vector3.Distance(transform.position, currentTarget.transform.position) <= stats.AttackRange)
        {
            currentState = EnemyState.AttackTarget;
        }
    }

    protected virtual void SetBaseTarget()
    {
        var possibleTargets = GameObject.FindGameObjectsWithTag("Player");

        if(possibleTargets.Length == 1)
            currentTarget = possibleTargets[0];
        else
            currentTarget = possibleTargets[Random.Range(0, possibleTargets.Length + 1)];

        currentState = EnemyState.MoveToTargetPosition;
    }

    protected virtual void MoveTowardsCurrentTarget()
    {
        agent.SetDestination(currentTarget.transform.position);
    }

    protected virtual void CheckForOtherTargetsInRange()
    {
        var thingsInRange = Physics.OverlapSphere(transform.position, stats.SearchRange, stats.EnemyLayerMask);

        if(thingsInRange.Length == 1)
        {
            currentTarget = thingsInRange[0].gameObject;
        }
        else if(thingsInRange.Length > 1)
        {
            currentTarget = thingsInRange[Random.Range(0, thingsInRange.Length + 1)].gameObject;
        }
    }

    [ServerCallback]
    protected void OnDamageTaken(float damageTaken)
    {
        currentHealth -= damageTaken;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {

    }

    private void OnHealthChanged(float oldHealthValue, float newHealthValue)
    {
        if (newHealthValue >= stats.MaxHealth)
            enemyHealthBar.SetActive(false);
        else if(newHealthValue <= stats.MaxHealth && enemyHealthBar.activeSelf == false)
            enemyHealthBar.SetActive(true);
    }
}

public enum EnemyState 
{ 
    SetTarget,
    MoveToTargetPosition,
    CheckForCloserTarget,
    AttackTarget,
    BetweenAttacks
}

