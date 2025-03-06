using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _clampAngle = 80;

    private Mover _playerMover;
    private float _verticalRotation;
    private float _horizontalRotation;

    private void Awake()
    {
        _playerMover = GetComponentInParent<Mover>();
    }

    private void Start()
    {
        _verticalRotation = transform.localEulerAngles.x;
        _horizontalRotation = _playerMover.transform.eulerAngles.y;

    }
    private void FixedUpdate()
    {
        Rotate();
    }

   private void Rotate()
    {
        float verticalInput = -Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        _verticalRotation += verticalInput * _rotationSpeed * Time.deltaTime;
        _horizontalRotation += horizontalInput * _rotationSpeed * Time.deltaTime;

        _verticalRotation = Mathf.Clamp(_verticalRotation, -_clampAngle, _clampAngle);

        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        _playerMover.transform.rotation = Quaternion.Euler(0f, _horizontalRotation, 0f);
    }
}


