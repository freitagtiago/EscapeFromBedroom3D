using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IInteractable
{
    [SerializeField] ItemConfig item;
    [SerializeField] bool isLocked = true;
    [SerializeField] ItemConfig itemToOpen;

    public void Interact()
    {
        if (isLocked) 
        {
            if (Inventory.instance.HasThisItem(itemToOpen))
            {
                isLocked = false;
                UIHandler.instance.WarningRoutine("Usando " + itemToOpen.itemName + ", conseguiu abrir o armário");
            }
            else
            {
                UIHandler.instance.WarningRoutine("A porta esta emperrada");
                return;
            }
        }
        else
        {
            if (item != null)
            {
                Inventory.instance.AddItem(item);
                item = null;
            }
            else
            {
                UIHandler.instance.WarningRoutine("Nada foi encontrado por aqui.");
            }
        }
    }
}
