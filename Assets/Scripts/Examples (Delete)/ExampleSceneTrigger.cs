using UnityEngine;

public class ExampleSceneTrigger : MonoBehaviour
{
    [SerializeField] PassageEventSO SceneChanger;
    [SerializeField] DoorSO passage;
    [SerializeField] ConnectionSO connection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("1");
        if(collision.tag == "Player")
            SceneChanger.RaiseEvent(passage, connection, passage.sceneToLoad);
    }
}