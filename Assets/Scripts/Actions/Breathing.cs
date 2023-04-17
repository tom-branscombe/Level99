using UnityEngine;

public class Breathing : MonoBehaviour
{
    [Header("Input Reader")]
    [SerializeField] InputReaderSO inputReaderSO = default;

    [Header("UI")]
    [SerializeField] GameObject mover;
    [SerializeField] bool tempBreatheEvent = true;

    private void OnEnable()
    {
        //Register event
        inputReaderSO.breatheEvent += OnBreathe;
    }

    private void OnDisable()
    {
        //Unregister event to prevent reference errors for object lifetime.
        inputReaderSO.breatheEvent -= OnBreathe;
    }

    private void OnBreathe(float input)
    {
        if (!tempBreatheEvent) return;
        //if the player is not in darkness do not continue
        var activity = input > 0 ? true : false;
        if (!activity) return;
        print(input);
    }
}
