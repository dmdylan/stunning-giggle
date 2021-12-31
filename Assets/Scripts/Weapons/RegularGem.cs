using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGem : BaseGem
{
    public override GameObject FireProjectile()
    {
        canFire = false;

        ReduceCurrentEnergy(gemStats.EnergyCostPerShot);
        Debug.Log("Fired!");

        var projectilePrefab = Instantiate(gemStats.ProjectilePrefab, firePoint);

        StartCoroutine(TimeBetweenShots());

        return projectilePrefab;
    }

    public override Vector3 FireRayCast()
    {
        throw new System.NotImplementedException();
    }
}
