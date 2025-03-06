using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody rig;
    
    [SerializeField] private Transform _cameraTransform;
    private Vector3 _finalPosCamera;
    private Vector3 _initialPosCamera;    

    [SerializeField] private float _movementForce = 10f;
    [SerializeField] private float _squatHeight = 4f;
    
    [SerializeField] private bool _isSquating = false;
    [SerializeField] private bool _doingMovement = false;
    [SerializeField] private bool _canMove = true;

    [SerializeField] private AudioClip[] _stepSoundArray;
    [SerializeField] private AudioSource _audioSource;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _initialPosCamera = _cameraTransform.position;
    }

    void FixedUpdate()
    {
        if (!_canMove) 
        { 
            return; 
        }

        Move();
        Squat();
    }

    private void Move()
    {
        if(rig.velocity.magnitude >= _movementForce 
            || _isSquating) 
        { 
            return; 
        }

        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(_movementForce * -transform.right);
            PlayAudio();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(_movementForce * transform.right);
            PlayAudio();
        }
        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(_movementForce * transform.forward);
            PlayAudio();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(_movementForce * -transform.forward);
            PlayAudio();
        }
    }

    private void Squat()
    {
        if (Input.GetKey(KeyCode.Space) 
            && !_doingMovement)
        {
            _initialPosCamera = _cameraTransform.position;

            if (_isSquating)
            {
                _finalPosCamera = new Vector3(_initialPosCamera.x, _initialPosCamera.y + _squatHeight, _initialPosCamera.z);
            }
            else
            {
                _finalPosCamera = new Vector3(_initialPosCamera.x, _initialPosCamera.y - _squatHeight, _initialPosCamera.z);
            }

            _doingMovement = true;
            rig.isKinematic = true;
            _isSquating = !_isSquating;
        }

        if (!_doingMovement)
        { 
            return; 
        }

        float step = 2f * Time.deltaTime;

        _cameraTransform.position = Vector3.MoveTowards(_cameraTransform.position, _finalPosCamera, step);
        if(_cameraTransform.position == _finalPosCamera)
        {
            rig.isKinematic = false;
            _doingMovement = false;
        }
    }

    private void PlayAudio()
    {
        if (_audioSource.isPlaying) 
        { 
            return; 
        }
        _audioSource.clip = _stepSoundArray[Random.Range(0, _stepSoundArray.Length - 1)];
        _audioSource.Play();
    }

    public void SetCanMove(bool value)
    {
        _canMove = value;
    }
}
