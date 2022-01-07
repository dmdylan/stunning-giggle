using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Base Stats", menuName = "Scriptable Objects/Base Stats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float baseDamage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private List<Ability> abilities;

    public float MaxHealth => maxHealth;
    public float BaseDamage => baseDamage;
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public float AttackRate => attackRate;
    public LayerMask EnemyLayerMask => enemyLayerMask;
    public List<Ability> Abilities => abilities;
}

[Serializable]
public struct Ability
{
    public string abilityName;
    public float abilityDamage;
    public float abilityCooldown;
    public string abilityDescription;
}
