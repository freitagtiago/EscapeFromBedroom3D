using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IInteractable
{
    [SerializeField] string sentence;

    public void Interact()
    {
        UIHandler.instance.MessageDisplayer(sentence);
    }
}
