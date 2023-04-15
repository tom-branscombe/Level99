using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Interactable Event Channel")]
public class InteractableEventChannelSO : ScriptableObject
{
    //holds event
    public UnityAction<Interactable> OnEventRaised;

    //has a public raise event
    public void RaiseEvent(Interactable interactable)
    {
        //invokes on call
        OnEventRaised?.Invoke(interactable);
    }
}