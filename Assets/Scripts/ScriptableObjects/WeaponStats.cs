using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon Stats", fileName = "New Weapon Stats")]
public class WeaponStats : ScriptableObject
{
    [Header("Damage Properties")]
    [SerializeField] private float baseDamage;
    [SerializeField] private float effectiveRange;
    [SerializeField] private float maxRange;
    [SerializeField] private AnimationCurve dropOffDamageCurve;
    [SerializeField] private int maxEnergy;

    [Space(10)]

    [Header("Cosmetic Properties")]
    [SerializeField] private Color gemColor;
    [SerializeField] private Material gemMaterial;

    public float BaseDamage => baseDamage;
    public float EffectRange => effectiveRange;
    public float MaxRange => maxRange;
    public AnimationCurve DropOffDamageCurve => dropOffDamageCurve;
    public float MaxEnergy => maxEnergy;
    public Color GemColor => gemColor;
    public Material GemMaterial { get { return gemMaterial; } private set { gemMaterial.color = gemColor; } }
}
