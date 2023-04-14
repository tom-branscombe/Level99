using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Game/Input Reader")]
public class InputReaderSO : ScriptableObject, Gameplay.IPlayerActions, Gameplay.IUIActions
{


    public event UnityAction<Vector2> moveEvent;


    private Gameplay gameplay;

    private void OnEnable()
    {
        if (gameplay == null)
        {
            gameplay = new Gameplay();
            gameplay.Player.SetCallbacks(this);
        }
        EnableGameplayInput();
    }

    private void OnDisable()
    {
        DisableGameplayInput();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }


    public void EnableGameplayInput()
    {
        gameplay.Player.Enable();
    }

    public void DisableGameplayInput()
    {
        gameplay.Player.Disable();
    }

}
