using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGem : BaseGem
{
    public override IEnumerator Fire()
    {
        canFire = false;

        ReduceCurrentEnergy(gemStats.EnergyCostPerShot);
        Debug.Log("Fired!");

        var projectilePrefab = Instantiate(gemStats.ProjectilePrefab, firePoint);
        
        yield return projectilePrefab;

        yield return new WaitForSeconds(gemStats.RateOfFire);

        canFire = true;
    }
}
