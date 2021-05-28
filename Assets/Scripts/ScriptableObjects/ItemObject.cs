using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ItemType
{
    Herbs
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
