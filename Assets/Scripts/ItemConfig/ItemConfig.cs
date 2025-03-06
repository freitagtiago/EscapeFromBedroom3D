using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "ItemConfig/New ItemConfig", order = 0)]

public class ItemConfig : ScriptableObject
{
    public string _itemName; 
    public string _itemInfo;
    public ItemType _itemType;
    public KeyType _keyType;
    public AudioClip _audioClip;
}
