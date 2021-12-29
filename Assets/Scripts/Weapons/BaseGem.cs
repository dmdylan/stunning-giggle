using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGem : MonoBehaviour
{
    [SerializeField] protected GemStats gemStats;
    [SerializeField] protected Transform firePoint;
    protected int currentEnergy;
    protected bool canFire = true;
    private bool isRecharging = false;

    public GemStats GemStats => gemStats;
    public bool CanFire => canFire;
    public int CurrentEnergy => currentEnergy;

    private void Start()
    {
        currentEnergy = gemStats.MaxEnergy;
    }

    public abstract IEnumerator Fire();

    ////TODO: Is this necessary if there is a reloading/recharing state?
    //public virtual IEnumerator RechargeGem()
    //{
    //    isRecharging = true;
    //    yield return new WaitForSeconds(gemStats.RechargeTime);
    //    isRecharging = false;
    //    currentEnergy = gemStats.MaxEnergy;
    //}

    //public virtual void CancelRecharge()
    //{
    //    if (isRecharging)
    //    {
    //        StopCoroutine(RechargeGem());
    //        isRecharging = false;
    //    }
    //}

    public void SetCurrentEneryToMaxEnergy()
    {
        currentEnergy = gemStats.MaxEnergy;
    }

    protected void ReduceCurrentEnergy(int energyCost)
    {
        if (currentEnergy - energyCost < 0)
            currentEnergy = 0;
        else
            currentEnergy -= energyCost;
    }
}
