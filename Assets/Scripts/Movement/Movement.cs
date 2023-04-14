using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private InputReaderSO _inputReader = default;


    private void OnEnable()
    {
        _inputReader.moveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.moveEvent -= OnMove;
    }


    private void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {

    }




    private void OnMove(Vector2 inputVector)
    {
        Debug.Log(inputVector.x);
    }

}
