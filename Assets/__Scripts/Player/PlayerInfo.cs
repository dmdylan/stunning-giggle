using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : NetworkBehaviour
{
    [SerializeField] private PlayerStats playerBaseStats;

    [SyncVar(hook = nameof(HealthChanged))]
    private int currentHealth;

    [SyncVar(hook = nameof(ManaChanged))]
    private int currentMana;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        CmdPlayerSetup(playerBaseStats.StartingHealth, playerBaseStats.StartingMana);

        StartCoroutine(TestChangeStats());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TestChangeStats()
    {
        currentHealth = UnityEngine.Random.Range(0, playerBaseStats.StartingHealth +1);
        currentMana = UnityEngine.Random.Range(0, playerBaseStats.StartingMana);

        yield return new WaitForSeconds(1f);

        StartCoroutine(TestChangeStats());
    }

    #region Methods

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        currentHealth -= amount;
        RpcDamage(amount);
    }

    public void GainMana(int amount)
    {
        CmdGainMana(amount);
    }

    public void SpendMana(int amount)
    {
        CmdSpendMana(amount);
    }

    private void HealthChanged(int oldAmount, int newAmount)
    {
        UIEventsManager.Instance.HealthChangeUI(newAmount);
    }

    private void ManaChanged(int oldAmount, int newAmount)
    {
        UIEventsManager.Instance.ManaChangedUI(newAmount);
    }

    #endregion

    #region Commands

    [Command]
    public void CmdGainMana(int amount)
    {
        currentMana += amount;
    }

    [Command]
    public void CmdSpendMana(int amount)
    {
        currentMana -= amount;
    }

    [Command]
    private void CmdPlayerSetup(int health, int mana)
    {
        currentHealth = health;
        currentMana = mana;
    }

    #endregion

    [ClientRpc]
    private void RpcDamage(int amount)
    {
        throw new NotImplementedException();
    }
}
