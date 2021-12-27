using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGem : MonoBehaviour
{
    [SerializeField] protected GemStats gemStats;
    protected int currentEnergy;

    private void Start()
    {
        currentEnergy = gemStats.MaxEnergy;
    }

    protected abstract void Fire();

    protected virtual IEnumerator RechargeGem()
    { 
        yield return null;
    }
}
