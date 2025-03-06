using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemConfig _item;
    [SerializeField] private bool _isLocked = true;
    [SerializeField] private ItemConfig _itemToOpen;

    public void Interact()
    {
        if (_isLocked) 
        {
            if (Inventory.Instance.HasThisItem(_itemToOpen))
            {
                _isLocked = false;
                UIHandler.Instance.WarningRoutine("Usando " + _itemToOpen._itemName + ", conseguiu abrir o armário");
            }
            else
            {
                UIHandler.Instance.WarningRoutine("A porta está emperrada");
                return;
            }
        }
        else
        {
            if (_item != null)
            {
                Inventory.Instance.AddItem(_item);
                _item = null;
            }
            else
            {
                UIHandler.Instance.WarningRoutine("Nada foi encontrado por aqui.");
            }
        }
    }
}
