using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Passage Event Channel")]
public class PassageEventSO : ScriptableObject
{
    //holds event
    public UnityAction<DoorSO, ConnectionSO, string> OnPassageRaised;

    //has a public raise event
    public void RaiseEvent(DoorSO passage, ConnectionSO connection, string sceneToLoad)
    {
        //invokes on call
        OnPassageRaised?.Invoke(passage, connection, sceneToLoad);
    }
}