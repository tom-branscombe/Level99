using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    ConnectionsSO _connection = default;
    [SerializeField]
    string _targetSceneName;
    [SerializeField]
    Transform spawnPoint;

    private void Start()
    {
        if (_connection != ConnectionsSO.ActiveConnection) return;
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        ConnectionsSO.ActiveConnection = _connection;
        SceneManager.LoadScene(_targetSceneName);
    }
}