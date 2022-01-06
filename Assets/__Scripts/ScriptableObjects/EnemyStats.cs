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
    [SerializeField] private float attackTime;

    public float MaxHealth { get { return maxHealth; } }
    public float BaseDamage { get {  return baseDamage; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackRange { get { return attackRange;} }
    public float AttackTime { get { return attackTime; } }  
}
