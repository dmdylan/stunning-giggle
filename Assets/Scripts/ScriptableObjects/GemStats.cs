using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gem Stats", menuName = "New Gem Stats")]
public class GemStats : ScriptableObject
{
    [Header("Damage Properties")]
    [SerializeField] private float baseDamage;
    [SerializeField] private float rateOfFire;
    [SerializeField] private bool isAutomatic;
    [SerializeField] private float effectiveRange;
    [SerializeField] private float maxRange;
    [SerializeField] private AnimationCurve dropOffDamageCurve;

    [Header("Energy Properties")]
    [SerializeField] private int maxEnergy;
    [SerializeField] private int eneryCostPerShot;
    [SerializeField] private int rechargeCost;
    [SerializeField] private float rechargeTime;

    public float BaseDamage => baseDamage;
    public float RateOfFire => rateOfFire;
    public bool IsAutomatic => isAutomatic;
    public float EffectRange => effectiveRange;
    public float MaxRange => maxRange;
    public AnimationCurve DropOffDamageCurve => dropOffDamageCurve;
    public int MaxEnergy => maxEnergy;
    public int EnergyCostPerShot => eneryCostPerShot;
    public int RechargeCost => rechargeCost;
    public float RechargeTime => rechargeTime;
}
