using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponController : MonoBehaviour
{
    public Transform firepoint;
    public Weapon currentWeapon;
    public List<Weapon> weaponList;
    private Player _player;

    public int currentIndex;

    public static event Action<Sprite> OnChangedWeapon;
    private void Awake()
    {
        _player = GetComponent<Player>();
        currentIndex = 0;
        currentWeapon = weaponList.First();
        
        _player.energyBar.SetMaxEnergy(_player.MaxEnergy);
        OnChangedWeapon?.Invoke(currentWeapon.Icon);
    }

    private void OnEnable()
    {
        InputManager.onFiring += Fire;
        InputManager.onSwapWeapon += SwapWeapon;
    }

    private void OnDisable()
    {
        InputManager.onFiring -= Fire;
        InputManager.onSwapWeapon -= SwapWeapon;
    }
    
    private void Fire()
    {
        //Verify if weapon is not null
        if (!currentWeapon) return;
            
        //if the projectile has energy consumption and has enough energy to cast, remove energy from player
        if (currentWeapon.EnergyConsumption <= _player.CurrentEnergy)
        {
            _player.CurrentEnergy -= currentWeapon.EnergyConsumption;
            _player.energyBar.SetEnergy(_player.CurrentEnergy);
        }
        else
            return;
        
        GameObject projectile = currentWeapon.Projectile;
        
        if (projectile.GetComponent<ProjectileBase>())
            projectile.GetComponent<ProjectileBase>().affiliatedWeapon = currentWeapon;
        
        else if (projectile.GetComponentInChildren<ProjectileBase>())
        {
            ProjectileBase[] childrenList = projectile.GetComponentsInChildren<ProjectileBase>();
            foreach (ProjectileBase projectileBase in childrenList)
                projectileBase.affiliatedWeapon = currentWeapon;
        }

        //Verify if instance of projectile exist otherwise don't fire
        
        //Instantiate projectile from fire point 
        Instantiate(projectile, firepoint.position, firepoint.rotation);
    }

    private void SwapWeapon(float obj)
    {
        if (obj > 0) // Scroll UP
        {
            currentIndex++;
            if (currentIndex > weaponList.Count - 1)
                currentIndex = 0;
        } 
        else if (obj < 0)// Scroll down
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = weaponList.Count - 1;
        } 
        currentWeapon = weaponList[currentIndex];
        OnChangedWeapon?.Invoke(currentWeapon.Icon);
    }
}
