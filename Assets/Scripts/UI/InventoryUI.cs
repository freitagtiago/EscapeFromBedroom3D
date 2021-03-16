using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    [SerializeField] ItemSlotUI itemSlotPrefab;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemInfo;
 
    private void Awake()
    {
        instance = this;
    }

    public void LoadItems()
    {
        SelectItem(null);
        List<ItemConfig> items = Inventory.instance.GetItemList();
        foreach (ItemConfig item in items)
        {
            var slot = Instantiate(itemSlotPrefab,transform);
            slot.Setup(item);
        }
    }

    public void ResetPanel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SelectItem(ItemConfig item)
    {
        if (item)
        {
            itemName.text = item.itemName;
            itemInfo.text = item.itemInfo;
        }
        else
        {
            itemName.text = "";
            itemInfo.text = "";
        }
    }
    
}
