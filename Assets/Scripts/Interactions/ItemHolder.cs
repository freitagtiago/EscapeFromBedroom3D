using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour, IInteractable
{
    [SerializeField] ItemConfig item;

    public void Interact()
    {
        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }

}
