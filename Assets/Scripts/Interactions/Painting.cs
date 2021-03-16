using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour, IInteractable
{
    [SerializeField] ItemConfig item;
    [SerializeField] string sentence;
    void Start()
    {
        
    }

    public void Interact()
    {
        if(item != null)
        {
            Inventory.instance.AddItem(item);
            item = null;
        }
        else
        {
            UIHandler.instance.WarningRoutine(sentence);
        }
    }
}
