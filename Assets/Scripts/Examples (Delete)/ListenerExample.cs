using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class ListenerExample : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO _changeIntensity;

    float _intensityFloat = 0.2f;

    void OnEnable()
    {
        _changeIntensity.OnEventRaised += ChangeLight;
    }

    private void OnDisable()
    {
        _changeIntensity.OnEventRaised -= ChangeLight;
    }

    void ChangeLight()
    {
        GetComponent<Light2D>().intensity = _intensityFloat;
    }
}