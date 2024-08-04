using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpinningRazor : ProjectileBase
{
    public Transform center;

    void Update()
    {
        transform.Rotate(Vector3.forward,affiliatedWeapon.ProjectileSpeed * Time.deltaTime);
        transform.RotateAround(center.position, Vector3.forward, affiliatedWeapon.ProjectileSpeed * Time.deltaTime);
    }
}
