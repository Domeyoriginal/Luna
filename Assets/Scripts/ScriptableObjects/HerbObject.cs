using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Herb Object",
    menuName = "Items/Herb")]
public class HerbObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Herbs;
    }
}
