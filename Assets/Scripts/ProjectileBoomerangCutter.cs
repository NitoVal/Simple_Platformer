using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBoomerangCutter : Projectile
{
    public Rigidbody2D rb;

    public float timer;
    public float lifeTime;
    private void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);    
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
                gameObject.SetActive(false);
            
            rb.AddForce(-transform.right * (3f * (affiliatedWeapon.ProjectileSpeed * Time.deltaTime)));
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(affiliatedWeapon.Damage);
    }

    protected override void OnTriggerEnter2D(Collider2D other) { }
}
