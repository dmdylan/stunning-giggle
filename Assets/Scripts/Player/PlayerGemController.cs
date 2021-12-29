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

    [SyncVar(hook = nameof(OnChangeGem))]
    private EquippedGem equippedGem;

    public event Action<EquippedGem> ChangeCurrentGem;

    public BaseGem CurrentWeapon => currentWeapon;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        currentWeapon = baseGemPrefab.GetComponent<BaseGem>();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        input = GetComponent<PlayerInput>();
        currentWeapon = baseGemPrefab.GetComponent<BaseGem>();
    }

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

    [Command]
    private void CmdChangeEquippedGem(EquippedGem newGem)
    {
        equippedGem = newGem;
    }
}
