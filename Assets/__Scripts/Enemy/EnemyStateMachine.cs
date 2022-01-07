using Mirror;
using NodeCanvas.BehaviourTrees;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : NetworkBehaviour
{
    [SerializeField] protected EnemyStats stats;

    [SyncVar]
    protected EnemyState currentState;

    [SyncVar]
    protected float currentHealth;

    public override void OnStartServer()
    {
        base.OnStartServer();
        currentHealth = stats.MaxHealth;
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
}

public enum EnemyState 
{ 
    Seek,
    Move,
    Attack
}

