using UnityEngine;

public class App : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootsrap()
    {
        var app = Object.Instantiate(Resources.Load("App"));
        if (app == null)
            throw new System.ApplicationException();

        Object.DontDestroyOnLoad(app);
    }
}
