using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject Inventory;
    public Transform lstItems;
    public List<InventorySlot> itemsDisplayed = new List<InventorySlot>();

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
