using UnityEngine;

public class ExampleSceneTrigger : MonoBehaviour
{
    [SerializeField] StringEventChannelSO SceneChanger;
    [SerializeField] bool _trigger = false;
    [SerializeField] string sceneName = "MainMenu";

    private void Update()
    {
        if (_trigger)
            SceneChanger.RaiseEvent(sceneName);
    }
}