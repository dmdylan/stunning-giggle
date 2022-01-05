using UnityEngine;

[CreateAssetMenu(fileName = "New Float Value", menuName = "Float Value")]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float value;

    public float Value => value;
}
