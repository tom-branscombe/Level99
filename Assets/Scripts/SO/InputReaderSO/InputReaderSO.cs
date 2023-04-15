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
    public event UnityAction interactionEvent;
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
        //If event is being listened, call the event with the vector2 (movement axis)
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactionEvent?.Invoke();
        }
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
