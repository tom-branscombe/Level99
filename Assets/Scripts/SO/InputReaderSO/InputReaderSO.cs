using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Game/Input Reader")]
public class InputReaderSO : ScriptableObject, Gameplay.IPlayerActions, Gameplay.IUIActions
{


    public event UnityAction<Vector2> moveEvent;
    public event UnityAction<float> breatheEvent;
    public event UnityAction interactionEvent;
    private Gameplay gameplay;

    private void OnEnable()
    {
        if (gameplay == null)
        {
            gameplay = new Gameplay();
            gameplay.Player.SetCallbacks(this);
            gameplay.UI.SetCallbacks(this);
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

    public void OnBreathe(InputAction.CallbackContext context)
    {
        breatheEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        interactionEvent?.Invoke();
    }


    public void EnableGameplayInput()
    {
        gameplay.Player.Enable();
        gameplay.UI.Enable();
    }

    public void DisableGameplayInput()
    {
        gameplay.Player.Disable();
        gameplay.UI.Disable();
    }
}