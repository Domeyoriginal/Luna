using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container;

    public void AddItem(ItemObject item, int count)
    {
        bool hasItem = false;
        for (int i = 0; i < 1; i++)
        {
            if (Container[i].Item == item)
            {
                Container[i].AddAmount(count);
                hasItem = true;
                break;
            }

            if (!hasItem)
            {
                Container.Add(new InventorySlot(item, count));
            }
        }
    }

    public void RemoveItem(ItemObject item)
    {
        Destroy(item);
        item = null;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject Item;
    public int Count;
    public InventorySlot(ItemObject item, int count)
    {
        Item = item;
        Count = count;
    }

    public void AddAmount(int value)
    {
        Count += value;
    }
}
