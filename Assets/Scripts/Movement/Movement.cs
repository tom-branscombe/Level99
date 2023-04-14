using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

    [SerializeField] InputReaderSO _inputReader = default;
    [SerializeField] float _movementSpeed = 5.0f;
    Rigidbody2D _rb;
    Vector2 _inputDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.moveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.moveEvent -= OnMove;
    }


    private void FixedUpdate()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {

        _rb.velocity = _inputDirection * _movementSpeed;

    }




    private void OnMove(Vector2 inputVector)
    {
        _inputDirection = inputVector.normalized;
    }

}
