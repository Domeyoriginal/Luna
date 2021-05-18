using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBrewInvenotry : MonoBehaviour
{
    public InventoryObject Inventory;
    public Transform lstItems;

    void Start()
    {
        CreateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            var obj = Instantiate(Inventory.Container[i].Item.prefab, lstItems);
        }
    }
}
