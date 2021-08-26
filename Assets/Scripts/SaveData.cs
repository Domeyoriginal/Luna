using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public Vector3 playerPosition;
    public List<InventorySlot> inventory;

    public SaveData(ThirdPersonMovement player, InventoryObject inv)
    {
        playerPosition = player.transform.position;
        inventory = inv.Container;
    }
}
