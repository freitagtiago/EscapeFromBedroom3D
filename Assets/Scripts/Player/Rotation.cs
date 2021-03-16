using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float clampAngle = 80;

    Mover player;
    float verticalRotation;
    float horizontalRotation;

    private void Awake()
    {
        player = GetComponentInParent<Mover>();
    }

    private void Start()
    {
        verticalRotation = transform.localEulerAngles.x;
        horizontalRotation = player.transform.eulerAngles.y;

    }
    private void FixedUpdate()
    {
        Rotate();
    }

   private void Rotate()
    {
        float verticalInput = -Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        verticalRotation += verticalInput * rotationSpeed * Time.deltaTime;
        horizontalRotation += horizontalInput * rotationSpeed * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        player.transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }
}


