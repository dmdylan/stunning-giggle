using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGem : BaseGem
{
    public override IEnumerator Shoot()
    {
        canFire = false;

        ReduceCurrentEnergy(gemStats.EnergyCostPerShot);
        Debug.Log("Fired");

        var gemProjectile = Instantiate(gemStats.ProjectilePrefab, firePoint.position, firePoint.rotation);

        gemController.SpawnProjectile(gemProjectile);

        yield return new WaitForSeconds(gemStats.RateOfFire);

        canFire = true;
    }
}
