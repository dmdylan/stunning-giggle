using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGem : BaseGem
{
    public override IEnumerator Shoot()
    {
        gemController.CanFire = false;

        var gemProjectile = Instantiate(gemStats.ProjectilePrefab, firePoint.position, firePoint.rotation);

        gemController.SpawnProjectile(gemProjectile);

        gemController.ReduceCurrentEnergy(gemStats.EnergyCostPerShot);
        Debug.Log("Fired");
        
        if (gemController.IsRecharging)    
            yield break;

        yield return new WaitForSeconds(gemStats.RateOfFire);

        gemController.CanFire = true;
    }
}
