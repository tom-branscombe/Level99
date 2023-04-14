using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] StringEventChannelSO _sceneChanger;

    //example (will be private event based)
    private void OnEnable()
    {
        _sceneChanger.OnEventRaised += ChangeScene;
    }

    private void ChangeScene(string input)
    {
        SceneManager.LoadScene(input);
    }
}