using NodeCanvas.BehaviourTrees;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyStats stats;
    protected event Action<float> DamageTaken;
    protected float currentHealth;
    private BehaviourTreeOwner behaviourTree;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = stats.MaxHealth;
        //behaviourTree = GetComponent<BehaviourTreeOwner>();
        //behaviourTree.StartBehaviour(behaviourTree.behaviour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        DamageTaken += OnDamageTaken;
    }

    private void OnDisable()
    {
        DamageTaken -= OnDamageTaken;
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
