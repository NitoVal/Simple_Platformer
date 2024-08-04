using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float MaxHP = 50f;
    public float CurrentHp;
    public float MaxEnergy = 25f;
    public float CurrentEnergy;
    private float _invulnerabilityTimer;
    
    public HealthBar hpBar;
    public EnergyBar energyBar;
    public SpriteRenderer spriteRenderer;
    
    public static event Action OnDeath;
    void Awake()
    {
        CurrentHp = MaxHP;
        CurrentEnergy = MaxEnergy;
        
        hpBar.SetMaxHealth(MaxHP);
    }

    private void Update()
    {
        if (_invulnerabilityTimer > 0)
            _invulnerabilityTimer -= Time.deltaTime;
        else
            spriteRenderer.color = Color.white;
    }

    public void TakeDamage(float damage)
    {
        if (_invulnerabilityTimer <= 0)
        {
            CurrentHp -= damage;
            hpBar.SetHealth(CurrentHp);
        
            if (CurrentHp <= 0)
                Die();

            _invulnerabilityTimer = 1f;
            spriteRenderer.color = Color.gray;
        }
    }

    private void Die()
    {
        hpBar.SetHealth(0);
        gameObject.SetActive(false);
        
        OnDeath?.Invoke();
    }

    public void Heal(float amount)
    {
        CurrentHp += amount;
        
        if (CurrentHp > MaxHP)
            CurrentHp = MaxHP;
        
        hpBar.SetHealth(CurrentHp);
    }

    public void RecoverEnergy(float amount)
    {
        CurrentEnergy += amount;
        if (CurrentEnergy > MaxEnergy)
            CurrentEnergy = MaxEnergy;
        
        energyBar.SetEnergy(CurrentEnergy);
    }

    public void IncreaseHp()
    {
        MaxHP += 10f;
        CurrentHp += 10f;
        hpBar.UpgradeHpBar(CurrentHp, MaxHP);
    }
    public void IncreaseMaxEnergy()
    {
        MaxEnergy += 10f;
        CurrentEnergy += 10f;
        energyBar.UpgradeEnergyBar(CurrentEnergy, MaxEnergy);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
            other.gameObject.GetComponent<IPickupBase>().Pickup(this);
        
        if (other.gameObject.CompareTag("DeathObstacle"))
            Die();

        if (other.gameObject.CompareTag("Enemy"))
            TakeDamage(other.gameObject.GetComponent<EnemyBase>().damage);
    }
}
