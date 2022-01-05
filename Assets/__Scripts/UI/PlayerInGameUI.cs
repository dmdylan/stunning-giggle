using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInGameUI : MonoBehaviour
{
    //[SerializeField] private Image healthBar;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI currentGemEnergyText;
    [SerializeField] private TextMeshProUGUI maxGemEnergyText;
    [SerializeField] private TextMeshProUGUI totalManaText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        UIEventsManager.Instance.OnGemEnergyChange += Instance_OnGemEnergyChange;
        UIEventsManager.Instance.OnHealthChange += Instance_OnHealthChange;
        UIEventsManager.Instance.OnManaChanged += Instance_OnManaChanged;
        UIEventsManager.Instance.OnSetMaxGemEnergy += Instance_OnSetMaxGemEnergy;
    }

    private void OnDisable()
    {
        UIEventsManager.Instance.OnGemEnergyChange -= Instance_OnGemEnergyChange;
        UIEventsManager.Instance.OnHealthChange -= Instance_OnHealthChange;
        UIEventsManager.Instance.OnManaChanged -= Instance_OnManaChanged;
        UIEventsManager.Instance.OnSetMaxGemEnergy -= Instance_OnSetMaxGemEnergy;
    }

    private void Instance_OnManaChanged(int value)
    {
        totalManaText.text = value.ToString();
    }

    private void Instance_OnHealthChange(int value)
    {
        healthSlider.value = value;
    }

    private void Instance_OnGemEnergyChange(int value)
    {
        currentGemEnergyText.text = value.ToString();
    }

    private void Instance_OnSetMaxGemEnergy(int value)
    {
        maxGemEnergyText.text = value.ToString();
    }
}
