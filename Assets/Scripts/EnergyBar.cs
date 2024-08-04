using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private RectTransform _energyBarTransform;

    private void Awake()
    {
        _energyBarTransform = GetComponent<RectTransform>();
    }

    public void SetMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void UpgradeEnergyBar(float currentEnergy, float maxEnergy)
    {
        //increase max energy
        slider.maxValue = maxEnergy;
        slider.value = currentEnergy;

        //increase width of the bar
        _energyBarTransform.sizeDelta = new Vector2(_energyBarTransform.sizeDelta.x + 25f,_energyBarTransform.sizeDelta.y);
    }
}
