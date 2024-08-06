using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSplitShot : Projectile
{
    public Rigidbody2D rb;
    public Transform projectileTransform;
    void Awake()
    {
        rb.AddForce(projectileTransform.right * affiliatedWeapon.ProjectileSpeed);
    }
}
