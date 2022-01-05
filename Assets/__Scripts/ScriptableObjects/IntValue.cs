using UnityEngine;

[CreateAssetMenu(fileName = "New Int Value", menuName = "Int Value")]
public class IntValue : ScriptableObject
{
    [SerializeField] private int value;

    public int Value => value;
}
