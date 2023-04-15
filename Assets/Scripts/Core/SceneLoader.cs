using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] PassageEventSO _sceneChanger;
    [SerializeField] GameObject Player;

    private void OnEnable()
    {
        _sceneChanger.OnPassageRaised += ChangeScene;
    }

private void ChangeScene(DoorSO entered, ConnectionSO connection, string sceneToLoad)
    {
        print("Hello");
        SceneManager.LoadScene(sceneToLoad);
        foreach (var route in connection.routes)
        {
            if(route.passageLetter != entered.passageLetter)
            {
                //this will be the exit not entrance
                //player will spawn at position
                Instantiate(Player, new Vector2(route.position.x, route.position.y), Quaternion.identity);
            }
        }
    }
}