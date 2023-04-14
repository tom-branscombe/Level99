using UnityEngine;

public class BroadCasterExample : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO _changeIntensity;

    //if something happens Example trigger
    [SerializeField] bool _trigger = false;

    void Update()
    {
        if (_changeIntensity != null && _trigger)
            //calling the events invoke
            _changeIntensity.RaiseEvent();
    }
}