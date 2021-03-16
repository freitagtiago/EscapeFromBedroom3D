using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] List<ItemConfig> items = new List<ItemConfig>();

    private void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddItem(ItemConfig itemToAdd)
    {
        if (itemToAdd.audioClip)
        {
            Debug.Log("tocou");
            AudioSource.PlayClipAtPoint(itemToAdd.audioClip, transform.position);
        }
        items.Add(itemToAdd);
        UIHandler.instance.WarningRoutine("O item " + itemToAdd.itemName + " foi encontrado");
    }

    public bool HasThisKey(KeyType neededKey)
    {
        bool found = false;
        foreach(ItemConfig item in items)
        {
            if(item.keyType == neededKey)
            {
                found = true;
                items.Remove(item);
                break;
            }
        }
        return found;
    }

    public bool HasThisItem(ItemConfig itemNeeded)
    {
        bool found = false;
        foreach(ItemConfig item in items)
        {
            if(itemNeeded == item)
            {
                found = true;
                break;
            }
        }

        return found;
    }

    public List<ItemConfig> GetItemList()
    {
        return items;
    }
}
