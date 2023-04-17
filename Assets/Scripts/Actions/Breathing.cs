using UnityEngine;

public class Breathing : MonoBehaviour
{
    [Header("Input Reader")]
    [SerializeField] InputReaderSO inputReaderSO = default;

    [Header("UI")]
    [SerializeField] GameObject UI;
    [SerializeField] GameObject mover;
    [SerializeField] GameObject target;
    [SerializeField] bool tempBreatheEvent = false;
    [SerializeField] bool holdinglocal = false;
    [SerializeField] int targetPos;
    [SerializeField] float leeway;

    float lowbound = -0.8f;
    float highbound = 0.8f;

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
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnBreatheEvent();
        }

        if (tempBreatheEvent)
        {
            var dir = holdinglocal ? 0.001f : -0.001f;
            if (mover.transform.localPosition.y < lowbound)
                mover.transform.localPosition = new Vector3(mover.transform.localPosition.x, lowbound, mover.transform.localPosition.z);
            if (mover.transform.localPosition.y > highbound)
                mover.transform.localPosition = new Vector3(mover.transform.localPosition.x, highbound, mover.transform.localPosition.z);

            if (!(mover.transform.localPosition.y > targetPos * 0.1f + leeway || mover.transform.localPosition.y < targetPos * 0.1f - leeway))
            {
                TargetHit();
            }

            mover.transform.localPosition += new Vector3(0, dir, 0);
        }
    }

    private void TargetHit()
    {
        mover.transform.localPosition = Vector3.zero;
        target.transform.localPosition = Vector3.zero;
        UI.SetActive(false);
        tempBreatheEvent = false;
    }


    //trigger on breathe event
    private void OnBreatheEvent()
    {
        targetPos = Random.Range(8, -8);
        UI.SetActive(true);
        tempBreatheEvent = true;
        target.transform.localPosition = new Vector3(target.transform.localPosition.x, targetPos * 0.1f, target.transform.localPosition.z);
    }

    private void OnBreathe(float input, bool holding)
    {
        holdinglocal = holding;
    }
}