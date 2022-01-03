using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquippedGem : byte 
{ 
    baseGem,
    otherGem
}

public class PlayerGemController : NetworkBehaviour
{
    [SerializeField] private GameObject baseGemPrefab;
    [SerializeField] private Transform gemLocation;

    private BaseGem currentWeapon;
    private PlayerInput input;

    private GameObject gemProjectile;
    private Transform firePoint;

    [SyncVar(hook = nameof(OnChangeGem))]
    private EquippedGem equippedGem;

    public event Action<EquippedGem> ChangeCurrentGem;

    public BaseGem CurrentWeapon => currentWeapon;

    private void Start()
    {
        input = GetComponent<PlayerInput>();

        var gem = Instantiate(baseGemPrefab, gemLocation);

        currentWeapon = gem.GetComponent<BaseGem>();

        if(currentWeapon != null)
        {
            firePoint = currentWeapon.FirePoint;
            currentWeapon.GemController = this;

            if(currentWeapon.GemStats.ProjectilePrefab != null)
                gemProjectile = currentWeapon.GemStats.ProjectilePrefab;
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        Debug.Log("Can fire: " + currentWeapon.CanFire);

        if (input.IsShooting && currentWeapon.CanFire)
        {
            StartCoroutine(currentWeapon.Shoot());
            //if (currentWeapon.GemStats.ShootingType == ShootingType.Projectile)
            //    SpawnProjectile();
        }
        
    }

    //public override void OnStartLocalPlayer()
    //{
    //    base.OnStartLocalPlayer();
    //    input = GetComponent<PlayerInput>();
    //    currentWeapon = baseGemPrefab.GetComponent<BaseGem>();
    //}

    private void OnEnable()
    {
        ChangeCurrentGem += OnChangeCurrentGem;
    }

    private void OnDisable()
    {
        ChangeCurrentGem -= OnChangeCurrentGem;
    }

    private void OnChangeCurrentGem(EquippedGem newGem)
    {
        CmdChangeEquippedGem(newGem);
    }

    private void OnChangeGem(EquippedGem oldEquippedGem, EquippedGem newEquippedGem)
    {
        StartCoroutine(ChangeGems(newEquippedGem));
    }

    IEnumerator ChangeGems(EquippedGem equippedGem)
    {
        while(gemLocation.childCount > 0)
        {
            Destroy(gemLocation.GetChild(0).gameObject);
            yield return null;
        }

        switch (equippedGem) 
        { 
            case EquippedGem.baseGem:
                currentWeapon = baseGemPrefab.GetComponent<BaseGem>();
                break;
            case EquippedGem.otherGem:
                break;
        }
    }

    public void ChangeEquippedGem(EquippedGem newGem)
    {
        ChangeCurrentGem?.Invoke(newGem);
    }

    public void SpawnProjectile(GameObject projectile)
    {
        //var projectilePrefab = Instantiate(gemProjectile, firePoint.position, firePoint.rotation);

        if(!isServer)
            CmdSpawnProjectile(projectile);
    }

    [Command]
    private void CmdChangeEquippedGem(EquippedGem newGem)
    {
        equippedGem = newGem;
    }

    [Command]
    private void CmdSpawnProjectile(GameObject shootProjectile)
    {
        NetworkServer.Spawn(shootProjectile);
    }
}
