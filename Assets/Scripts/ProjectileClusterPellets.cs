using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClusterPellets : Projectile
{
    public Rigidbody2D rb;
    public float lifeTime;
    void Start()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed* 1.5f);
    }
    
    void Update()
    {
        if (lifeTime <= 0)
            gameObject.SetActive(false);
        lifeTime -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
    }
}
