using System.Collections;
using UnityEngine;

public abstract class BaseGem : MonoBehaviour
{
    [SerializeField] protected GemStats gemStats;
    [SerializeField] protected Transform firePoint;
    protected int currentEnergy;
    protected bool canFire = true;
    protected PlayerGemController gemController;
    protected PlayerInput input;

    public GemStats GemStats => gemStats;
    public Transform FirePoint => firePoint;
    public PlayerGemController GemController { get { return gemController; } set { gemController = value; } }

    public abstract IEnumerator Shoot();
}
