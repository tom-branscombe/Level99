using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Input Reader")]
    [SerializeField] InputReaderSO _inputReader = default;

    [Header("Movement Parameters")]
    [SerializeField] float _movementSpeed = 5.0f;


    //private vars
    private float _previousSpeed;

    Rigidbody2D _rb;
    Vector2 _inputDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //Register event
        _inputReader.moveEvent += OnMove;
    }

    private void OnDisable()
    {
        //Unregister event to prevent reference errors for object lifetime.
        _inputReader.moveEvent -= OnMove;
    }


    private void FixedUpdate()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {

        float targetSpeed = Mathf.Clamp01(_inputDirection.magnitude);
        if (targetSpeed > 0f)
        {
            targetSpeed = _movementSpeed;
        }
        //If player is moving get constant movespeed.

        //Interpolate between previousSpeed and targetSpeed
        targetSpeed = Mathf.Lerp(_previousSpeed, targetSpeed, Time.deltaTime * 4f);

        //Add to player velocity.
        _rb.velocity = _inputDirection * targetSpeed;

        //Set the previous speed.
        _previousSpeed = targetSpeed;

    }

    private void OnMove(Vector2 inputVector)
    {
        _inputDirection = inputVector.normalized;
    }

}
