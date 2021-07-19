using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ItemType
{
    Herbs,
    Potion
}

public abstract class ItemObject : ScriptableObject
{
    public string Name;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
