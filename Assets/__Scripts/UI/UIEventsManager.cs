using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventsManager : NetworkBehaviour
{
    static UIEventsManager instance;
    
    public static UIEventsManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIEventsManager>();
            
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public event Action<int> OnGemEnergyChange;
    public void ChangeGemEnergyUI(int amount) => OnGemEnergyChange?.Invoke(amount);

    public event Action<int> OnHealthChange;
    public void HealthChangeUI(int amount) => OnHealthChange?.Invoke(amount);

    public event Action<int> OnManaChanged;
    public void ManaChangedUI(int amount) => OnManaChanged?.Invoke(amount);

    public event Action<int> OnSetMaxGemEnergy;
    public void SetMaxGemEnergyUI(int amount) => OnSetMaxGemEnergy?.Invoke(amount);
}
