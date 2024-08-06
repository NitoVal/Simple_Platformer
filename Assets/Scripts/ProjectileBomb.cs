using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileBomb : Projectile
{
    public Rigidbody2D rb;
    public LayerMask enemyMask;
    public float radius;
    public Transform sriteTransform;
    private void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }

    private void Update()
    {
        sriteTransform.Rotate(Vector3.forward,affiliatedWeapon.ProjectileSpeed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            //create an area of effect and damage enemy
            Collider2D[] hitList = Physics2D.OverlapCircleAll(gameObject.transform.position, radius, enemyMask);

            foreach (Collider2D hit in hitList)
                hit.GetComponent<EnemyBase>().TakeDamage(affiliatedWeapon.Damage);
            
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
