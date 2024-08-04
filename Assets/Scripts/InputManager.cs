using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInputActions actions;

    public static event Action<float> onMove;
    public static event Action onJump;

    public static event Action onFiring;

    public static event Action<float> onSwapWeapon;

    public static event Action onDash;
    
    public static event Action onPause;
    
    void OnEnable()
    {
        actions = new PlayerInputActions();
        actions.Enable();

        actions.Player.Move.performed += OnMove;
        actions.Player.Move.canceled += OnMove;

        actions.Player.Jump.performed += OnJump;

        actions.Player.Fire.performed += OnFiring;

        actions.Player.SwapWeapon.performed += OnSwapWeapon;

        actions.Player.Dash.performed += OnDash;

        actions.Player.Pause.performed += OnPause;
    }



    void OnDisable()
    {
        actions.Player.Move.performed -= OnMove;
        actions.Player.Move.canceled -= OnMove;
        
        actions.Player.Jump.performed -= OnJump;

        actions.Player.Fire.performed -= OnFiring;

        actions.Player.Pause.performed -= OnPause;
    }
    
    private void OnMove(InputAction.CallbackContext obj) { onMove?.Invoke(obj.ReadValue<float>()); }
    private void OnJump(InputAction.CallbackContext obj) { onJump?.Invoke(); }
    private void OnFiring(InputAction.CallbackContext obj) { onFiring?.Invoke(); }
    private void OnSwapWeapon(InputAction.CallbackContext obj) { onSwapWeapon?.Invoke(obj.ReadValue<float>()); }
    private void OnDash(InputAction.CallbackContext obj) { onDash?.Invoke(); }
    private void OnPause(InputAction.CallbackContext obj) { onPause?.Invoke(); }
}
