using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] Light lightObject;
    [SerializeField] AudioClip audioClip;
    public void Interact()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        Debug.Log(lightObject.enabled);
        lightObject.enabled = !lightObject.enabled; 
    }
}
