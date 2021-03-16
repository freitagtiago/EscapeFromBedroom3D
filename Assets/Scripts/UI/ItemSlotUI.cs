using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    ItemConfig itemOnSlot;
    [SerializeField] TMP_Text itemName;

    public void Setup(ItemConfig item)
    {
        this.itemOnSlot = item;
        this.itemName.text = itemOnSlot.itemName;
    }

    public void SelectItem()
    {
        InventoryUI.instance.SelectItem(itemOnSlot);
    }
}
