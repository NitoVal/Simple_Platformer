using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRayArrow : Projectile
{
    public Rigidbody2D rb;
    private void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(affiliatedWeapon.Damage);
    }
}
