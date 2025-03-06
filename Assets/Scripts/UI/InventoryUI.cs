using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    [SerializeField] private ItemSlotUI _itemSlotPrefab;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemInfo;
 
    private void Awake()
    {
        Instance = this;
    }

    public void LoadItems()
    {
        SelectItem(null);
        foreach (ItemConfig item in Inventory.Instance.GetItemList())
        {
            ItemSlotUI slot = Instantiate(_itemSlotPrefab,transform);
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
            _itemName.text = item._itemName;
            _itemInfo.text = item._itemInfo;
        }
        else
        {
            _itemName.text = "";
            _itemInfo.text = "";
        }
    }
    
}
