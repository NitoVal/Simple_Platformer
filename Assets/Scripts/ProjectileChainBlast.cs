using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Launches a bomb that can attaches to nearby bombs.
/// when the bomb is connected to 1 or 3 other bombs the blast point changes, the radius expands and the damage increases
/// </summary>
public class ProjectileChainBlast : Projectile
{
    const int MaxChainCount = 3;
    public float explosionRadius;
    public float detectionRadius;
    public float lifetime;
    private float _explosionDamage;
    
    private Vector2 _newCenter;
    public LayerMask bombMask;
    public LayerMask enemyMask;
    
    public Rigidbody2D rb;
    void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
        _explosionDamage = affiliatedWeapon.Damage;
    }

    private void Update()
    {
        Collider2D[] nearbyBombs = Physics2D.OverlapCircleAll(transform.position,detectionRadius,bombMask);
        foreach (Collider2D bomb in nearbyBombs)
        {
            //HOW TF
        }

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Explode();
    }
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //Stick the bomb if it hits an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.SetParent(other.gameObject.transform);
            rb.isKinematic = true;
        }
    }
    
    private void Explode()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius,enemyMask);
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyBase>().TakeDamage(_explosionDamage);
        }
        gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
