using UnityEngine;

public class Breathing : MonoBehaviour
{
    [Header("Input Reader")]
    [SerializeField] InputReaderSO inputReaderSO = default;

    [Header("UI")]
    [SerializeField] GameObject mover; 

    private void OnEnable()
    {
        //Register event
        inputReaderSO.breatheEvent += OnBreathe;
        print("Breathing");
    }

    private void OnDisable()
    {
        //Unregister event to prevent reference errors for object lifetime.
        inputReaderSO.breatheEvent -= OnBreathe;
    }

    private void OnBreathe(float input)
    {
        var activity = input > 0 ? true : false;
        if (!activity) return;
    }
}