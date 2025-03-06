using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] private Light _lightObject;
    [SerializeField] private AudioClip _audioClip;
    public void Interact()
    {
        AudioSource.PlayClipAtPoint(_audioClip, transform.position);
        _lightObject.enabled = !_lightObject.enabled; 
    }
}
