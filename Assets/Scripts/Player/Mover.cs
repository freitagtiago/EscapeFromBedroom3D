using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    Rigidbody rig;
    
    [SerializeField] Transform cameraTransform;
    Vector3 finalPosCamera;
    Vector3 initialPosCamera;    

    [SerializeField] float movementForce = 10f;
    [SerializeField] float squatHeight = 4f;
    
    [SerializeField] bool isSquating = false;
    [SerializeField] bool doingMovement = false;
    [SerializeField] bool canMove = true;

    [SerializeField] AudioClip[] stepSound;
    [SerializeField] AudioSource audioSource;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        initialPosCamera = cameraTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove) { return; }

        Move();
        Squat();
    }

    private void Move()
    {
        Debug.Log(rig.velocity.magnitude);
        Debug.Log(movementForce);
        if(rig.velocity.magnitude >= movementForce || isSquating) { return; }

        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(movementForce * -transform.right);
            PlayAudio();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(movementForce * transform.right);
            PlayAudio();
        }
        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(movementForce * transform.forward);
            PlayAudio();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(movementForce * -transform.forward);
            PlayAudio();
        }
    }

    private void Squat()
    {
        if (Input.GetKey(KeyCode.Space) && !doingMovement)
        {
            initialPosCamera = cameraTransform.position;

            if (isSquating)
            {
                finalPosCamera = new Vector3(initialPosCamera.x, initialPosCamera.y + squatHeight, initialPosCamera.z);
            }
            else
            {
                finalPosCamera = new Vector3(initialPosCamera.x, initialPosCamera.y - squatHeight, initialPosCamera.z);
            }

            doingMovement = true;
            rig.isKinematic = true;
            isSquating = !isSquating;
            Debug.Log("Agachou");
        }

        if (!doingMovement) return;

        float step = 2f * Time.deltaTime;

        cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, finalPosCamera, step);
        if(cameraTransform.position == finalPosCamera)
        {
            rig.isKinematic = false;
            doingMovement = false;
        }
    }

    private void PlayAudio()
    {
        if (audioSource.isPlaying) { return; }
        audioSource.clip = stepSound[Random.Range(0, stepSound.Length - 1)];
        audioSource.Play();
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
