using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion",
    menuName = "Items/Potion")]
public class PotionObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Potion;
    }
}
