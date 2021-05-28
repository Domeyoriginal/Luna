using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBrewInventory : MonoBehaviour
{
    public InventoryObject Inventory;

    public GameObject BrewPanel;
    public GameObject PressE;
    public GameObject Crosshair;

    public Transform lstItems;

    public bool hasCollided;

    private void Start()
    {
        BrewPanel.SetActive(false);
        PressE.SetActive(false);
        Crosshair.SetActive(true);
    }

    private void Update()
    {
        if (hasCollided && Input.GetKeyDown(KeyCode.E))
        {
            if (BrewPanel.activeSelf == true)
            {
                
            }
            else if (BrewPanel.activeSelf == false)
            {
                BrewPanel.SetActive(true);
                PressE.SetActive(false);
                Crosshair.SetActive(false);
                CreateBrewItemDisplay();
            }

            Time.timeScale = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            BrewPanel.SetActive(false);
            Crosshair.SetActive(true);
            Time.timeScale = 1;

            foreach (Transform child in lstItems)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public void CreateBrewItemDisplay()
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
