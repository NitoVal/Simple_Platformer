using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string WeaponName;
    
    [TextArea]
    public string WeaponDescription;

    public float EnergyConsumption;
    public float Damage;
    public float ProjectileSpeed;
    public GameObject Projectile;
    public Sprite Icon;
}
