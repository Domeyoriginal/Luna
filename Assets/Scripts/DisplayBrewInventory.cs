using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBrewInventory : MonoBehaviour
{
    public InventoryObject Inventory;

    public GameObject BrewPanel;
    public GameObject PressE;

    public Transform lstItems;

    public bool hasCollided;

    void Start()
    {
        BrewPanel.SetActive(false);
        PressE.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (hasCollided && Input.GetKey(KeyCode.E))
        {
            BrewPanel.SetActive(true);
            PressE.SetActive(false);
            CreateDisplay();
        }
        else if(!hasCollided)
        {
            BrewPanel.SetActive(false);
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            Instantiate(Inventory.Container[i].Item.prefab, lstItems);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasCollided = true;
            PressE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasCollided = false;
        PressE.SetActive(false);

        foreach (Transform child in lstItems)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        
    }
}
