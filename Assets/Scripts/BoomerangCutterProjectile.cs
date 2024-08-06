using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoomerangCutterProjectile : Projectile
{
    public Rigidbody2D rb;
    private Vector2 _initialPosition;

    public float timer;
    private void Awake()
    {
        _initialPosition = transform.position;
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);    
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
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
