using UnityEngine;

[CreateAssetMenu(fileName = "New Int Value", menuName = "Scriptable Objects/Int Value")]
public class IntValue : ScriptableObject
{
    [SerializeField] private int value;

    public int Value => value;
}
