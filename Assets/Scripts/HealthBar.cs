using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private RectTransform _hpBarTransform;

    private void Awake()
    {
        _hpBarTransform = GetComponent<RectTransform>();
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void UpgradeHpBar(float currentHp, float maxHealth)
    {
        //increase max hp
        slider.maxValue = maxHealth;
        slider.value = currentHp;
        
        //increase the width of the bar
        _hpBarTransform.sizeDelta = new Vector2(_hpBarTransform.sizeDelta.x + 25f,_hpBarTransform.sizeDelta.y);
    }
}
