using UnityEngine;

public class Breathing : MonoBehaviour
{
    [Header("Input Reader")]
    [SerializeField] InputReaderSO inputReaderSO = default;

    [Header("UI")]
    [SerializeField] GameObject mover;
    [SerializeField] bool tempBreatheEvent = true;
    [SerializeField] bool holdinglocal = false;

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

    private void Update()
    {
        if (!tempBreatheEvent) return;
        var dir = holdinglocal ? 0.001f : -0.001f;
        mover.GetComponent<RectTransform>().position += new Vector3(0, dir, 0);
    }

    private void OnBreathe(float input, bool holding)
    {
        holdinglocal = holding;
    }
}