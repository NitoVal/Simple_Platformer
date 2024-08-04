using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIconScript : MonoBehaviour
{
    private Image _icon;
    private void Awake()
    {
        _icon = GetComponent<Image>();
    }

    void OnEnable()
    {
        WeaponController.OnChangedWeapon += ChangeIcon;
    }

    private void OnDisable()
    {
        WeaponController.OnChangedWeapon -= ChangeIcon;
    }

    private void ChangeIcon(Sprite weaponIcon)
    {
        if (weaponIcon != null)
            _icon.sprite = weaponIcon;
    }
}
