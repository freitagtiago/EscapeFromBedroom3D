using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemConfig _item;

    public void Interact()
    {
        Inventory.Instance.AddItem(_item);
        Destroy(gameObject);
    }

}
