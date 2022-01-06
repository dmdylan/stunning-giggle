using UnityEngine;

[CreateAssetMenu(fileName = "New Float Value", menuName = "Scriptable Objects/Float Value")]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float value;

    public float Value => value;
}
