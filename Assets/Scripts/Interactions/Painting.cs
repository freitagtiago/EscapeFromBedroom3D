using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemConfig _item;
    [SerializeField] private string _sentence;

    public void Interact()
    {
        if(_item != null)
        {
            Inventory.Instance.AddItem(_item);
            _item = null;
        }
        else
        {
            UIHandler.Instance.WarningRoutine(_sentence);
        }
    }
}
