using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyStats stats;
    protected event Action<float> DamageTaken;
    protected float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = stats.MaxHealth;
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

    protected abstract void Die();
}
