using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGem : MonoBehaviour
{
    [SerializeField] protected GemStats gemStats;
    protected int currentEnergy;
    private bool isRecharging = false;

    private void Start()
    {
        currentEnergy = gemStats.MaxEnergy;
    }

    protected abstract void Fire();

    protected virtual IEnumerator RechargeGem()
    {
        isRecharging = true;
        yield return new WaitForSeconds(gemStats.RechargeTime);
        isRecharging = false;
        currentEnergy = gemStats.MaxEnergy;
    }

    public virtual void CancelRecharge()
    {
        if (isRecharging)
        {
            StopCoroutine(RechargeGem());
            isRecharging = false;
        }
    }
}
