using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInvetory : MonoBehaviour
{
    public InventoryObject Invetory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            Invetory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        Invetory.Container.Clear();
    }
}
