using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private float _speed = 7.5f;
    private float _xMovement;
    
    private float _grCheckRadius = .1f;
    private float _jumpForce = 15f;
    
    bool _isFacingRight = true;
    // private float _dashSpeed = 15f;
    // private float _dashDuration = .2f;
    // private float _dashCooldown = 1f;
    // private bool _isDashing;
    
    private Rigidbody2D _rb;
    
    public Transform grCheck;
    public LayerMask grMask;
    private bool _bIsGrounded;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        InputManager.onMove += GetMovementInputValue;
        InputManager.onJump += Jump;
        InputManager.onPause += TogglePause;
        InputManager.onDash += Dash;
    }


    private void OnDisable()
    {
        InputManager.onMove -= GetMovementInputValue;
        InputManager.onJump -= Jump;
        InputManager.onPause -= TogglePause;
        InputManager.onDash -= Dash;
    }

    // Update is called once per frame
    void Update()
    {
        _bIsGrounded = Physics2D.OverlapCircle(grCheck.position, _grCheckRadius, grMask);
        
        if (_xMovement > 0 && !_isFacingRight)
            Flip();
        if (_xMovement < 0 && _isFacingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xMovement * _speed, _rb.velocity.y);
    }
    
    private void GetMovementInputValue(float obj) { _xMovement = obj; }
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180f, 0);
    }
    private void Jump()
    {
        if (_bIsGrounded)
            _rb.velocity = Vector2.up * _jumpForce; 
    }
    private void Dash()
    {
        // for x amount of time, player goes in a direction 
    }

    private void TogglePause()
    {
        PauseMenu.Instance.Pause();
    }
}
