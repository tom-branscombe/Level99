using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    //holds event
    public UnityAction OnEventRaised;

    //has a public raise event
    public void RaiseEvent()
    {
        //invokes on call
        OnEventRaised?.Invoke();
    }
}