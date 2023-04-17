using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/String Event Channel")]
public class StringEventChannelSO : ScriptableObject
{
    //holds event
    public UnityAction<string> OnEventRaised;

    //has a public raise event
    public void RaiseEvent(string _input)
    {
        //invokes on call
        OnEventRaised?.Invoke(_input);
    }
}