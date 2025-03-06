using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IInteractable
{
    [SerializeField] private string _sentence;

    public void Interact()
    {
        UIHandler.Instance.MessageDisplayer(_sentence);
    }
}
