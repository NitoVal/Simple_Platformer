using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fire an ice crystal that explode when colliding with an enemy or terrain
/// when the crystal explode, it creates smaller pellets that also explode but with a smaller radius
/// </summary>
public class ProjectileClusterFrostbite : Projectile
{
    public Rigidbody2D rb;
    public GameObject clusterPellets;
    void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject pellet = Instantiate(clusterPellets, transform.position, transform.rotation);
        
        ProjectileClusterPellets[] childrenList = pellet.GetComponentsInChildren<ProjectileClusterPellets>();
        foreach (ProjectileClusterPellets projectile in childrenList)
            projectile.affiliatedWeapon = affiliatedWeapon;
        
        Destroy(gameObject);
    }
}
