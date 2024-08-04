using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSplitShot : ProjectileBase
{
    public Rigidbody2D rb;
    public Transform projectileTransform;
    void Awake()
    {
        rb.AddForce(projectileTransform.right * affiliatedWeapon.ProjectileSpeed);
    }
}
