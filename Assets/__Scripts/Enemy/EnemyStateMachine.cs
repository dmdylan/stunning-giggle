using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : NetworkBehaviour
{
    [SerializeField] protected EnemyStats stats;
    [SerializeField] private GameObject enemyHealthBar;

    [SerializeField] protected GameObject currentTarget;

    [SyncVar]
    protected EnemyState currentState;

    [SyncVar(hook = nameof(OnHealthChanged))]
    protected float currentHealth;

    protected NavMeshAgent agent;

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

    IEnumerator CheckForAttackablesInRange()
    {
        //Physics.OverlapSphere
            yield return null;
    }
    
    [Server]
    void CheckState()
    {
        switch (currentState)
        {
            case EnemyState.SetTarget:
                SetBaseTarget();
                break;
            case EnemyState.MoveToTargetPosition:
                MoveTowardsCurrentTarget();
                break;
            case EnemyState.CheckForCloserTarget:
                Debug.Log(currentState);
                break;
            case EnemyState.AttackTarget:
                Debug.Log(currentState);
                break;
            default:
                break;
        }
    }

    protected virtual void SetBaseTarget()
    {
        var possibleTargets = GameObject.FindGameObjectsWithTag("Player");

        foreach (var possibleTarget in possibleTargets)
            Debug.Log(possibleTarget);

        currentTarget = possibleTargets[Random.Range(0, possibleTargets.Length)];
        currentState = EnemyState.MoveToTargetPosition;
    }

    protected virtual void MoveTowardsCurrentTarget()
    {
        agent.SetDestination(currentTarget.transform.position);
        //currentState = EnemyState.CheckForCloserTarget;
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
    }
}

public enum EnemyState 
{ 
    SetTarget,
    MoveToTargetPosition,
    CheckForCloserTarget,
    AttackTarget
}

