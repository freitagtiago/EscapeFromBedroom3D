using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    private ItemConfig _itemOnSlot;
    [SerializeField] private TMP_Text _itemName;

    public void Setup(ItemConfig item)
    {
        this._itemOnSlot = item;
        this._itemName.text = _itemOnSlot._itemName;
    }

    public void SelectItem()
    {
        InventoryUI.Instance.SelectItem(_itemOnSlot);
    }
}
