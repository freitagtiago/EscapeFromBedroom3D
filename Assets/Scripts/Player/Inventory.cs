using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] private List<ItemConfig>  _itemList = new List<ItemConfig>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddItem(ItemConfig itemToAdd)
    {
        if (itemToAdd._audioClip)
        {
            AudioSource.PlayClipAtPoint(itemToAdd._audioClip, transform.position);
        }
        _itemList.Add(itemToAdd);
        UIHandler.Instance.WarningRoutine($"O item {itemToAdd._itemName} foi encontrado");
    }

    public bool HasThisKey(KeyType neededKey)
    {
        bool found = false;

        for(int i = _itemList.Count - 1; i != 0; i--)
        {
            if (_itemList[i]._keyType == neededKey)
            {
                found = true;
                _itemList.Remove(_itemList[i]);
                break;
            }
        }
        return found;
    }

    public bool HasThisItem(ItemConfig itemNeeded)
    {
        bool found = false;
        foreach(ItemConfig item in _itemList)
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
        return _itemList;
    }
}
