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
    private GemStats gemStats;

    private int currentEnergy;
    private bool canFire;
    private bool isRecharging;
    
    [SyncVar(hook = nameof(OnChangeGem))]
    private EquippedGem equippedGem;

    public event Action<EquippedGem> ChangeCurrentGem;

    public BaseGem CurrentWeapon => currentWeapon;
    public int CurrentEnergy => currentEnergy;
    public bool IsRecharging => isRecharging;
    public bool CanFire {get {return canFire;} set { canFire = value; } }

    private void Start()
    {
        input = GetComponent<PlayerInput>();

        var gem = Instantiate(baseGemPrefab, gemLocation);

        currentWeapon = gem.GetComponent<BaseGem>();

        if(currentWeapon != null)
        {
            GemSetup();
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (canFire && input.IsShooting)
        {
            StartCoroutine(currentWeapon.Shoot());
            UIEventsManager.Instance.ChangeGemEnergyUI(currentEnergy);
            Debug.Log("Current energy:" + currentEnergy);
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

    private void GemSetup()
    {
        gemStats = currentWeapon.GemStats;
        currentEnergy = gemStats.MaxEnergy;
        firePoint = currentWeapon.FirePoint;
        currentWeapon.GemController = this;
        canFire = true;

        if (gemStats.ProjectilePrefab != null)
            gemProjectile = gemStats.ProjectilePrefab;

        UIEventsManager.Instance.ChangeGemEnergyUI(currentEnergy);
        UIEventsManager.Instance.SetMaxGemEnergyUI(gemStats.MaxEnergy);
    }

    ////TODO: Is this necessary if there is a reloading/recharing state?
    public virtual IEnumerator RechargeGem()
    {
        isRecharging = true;
        yield return new WaitForSeconds(gemStats.RechargeTime);
        isRecharging = false;
        SetCurrentEneryToMaxEnergy();
    }

    private void CancelRecharge()
    {
        if (isRecharging)
        {
            StopCoroutine(RechargeGem());
            isRecharging = false;
        }
    }

    private void SetCurrentEneryToMaxEnergy()
    {
        currentEnergy = gemStats.MaxEnergy;
        canFire = true;
        UIEventsManager.Instance.ChangeGemEnergyUI(currentEnergy);
    }

    public void ReduceCurrentEnergy(int energyCost)
    {
        if (currentEnergy - energyCost <= 0)
        {
            currentEnergy = 0;
            canFire = false;
            StartCoroutine(RechargeGem());
        }
        else
            currentEnergy -= energyCost;
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
