using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "ItemConfig/New ItemConfig", order = 0)]

public class ItemConfig : ScriptableObject
{
    public string itemName; 
    public string itemInfo;
    public ItemType itemType;
    public KeyType keyType;
    public AudioClip audioClip;
}
