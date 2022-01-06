using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Scriptable Objects/Player Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private int startingHealth;
    [SerializeField] private int startingMana;

    public int StartingHealth => startingHealth;
    public int StartingMana => startingMana;
}
