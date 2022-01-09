using Mirror;
using NodeCanvas.BehaviourTrees;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : NetworkBehaviour
{
    [SerializeField] protected EnemyStats stats;
    [SerializeField] private GameObject enemyHealthBar;

    [SyncVar]
    protected EnemyState currentState;

    [SyncVar(hook = nameof(OnHealthChanged))]
    protected float currentHealth;

    public override void OnStartServer()
    {
        base.OnStartServer();
        currentHealth = stats.MaxHealth;
        currentState = EnemyState.Seek;
        InvokeRepeating("CheckState", 0f, .1f);
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

    void CheckState()
    {
        switch (currentState)
        {
            case EnemyState.Seek:
                Debug.Log(currentState);
                break;
            case EnemyState.Move:
                Debug.Log(currentState);
                break;
            case EnemyState.Attack:
                Debug.Log(currentState);
                break;
            default:
                break;
        }
    }

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
    Seek,
    Move,
    Attack
}

