using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileWaveBeam : Projectile
{
    public float speedOnX;
    public float amplitude;
    public float frequency;
    private float _x;
    private float _startY;
    private Vector2 _direction;
    
    public Rigidbody2D rb;
    private void Start()
    {
        _x = transform.position.x;
        _startY = transform.position.y;
        _direction = transform.right;
    }

    void Update()
    {
        _x += speedOnX * Time.deltaTime * _direction.x;
        float y = Mathf.Sin(_x * frequency) * amplitude + _startY;
        rb.MovePosition(new Vector2(_x, y));
    }
}