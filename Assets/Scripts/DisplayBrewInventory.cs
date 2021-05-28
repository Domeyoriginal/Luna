using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayBrewInventory : MonoBehaviour
{
    public InventoryObject Inventory;
    public List<PotionRecipe> Recipes;

    public GameObject BrewPanel;
    public GameObject PressE;
    public GameObject Crosshair;

    public Transform lstItems;
    public List<GameObject> buttons = new List<GameObject>();

    public List<Transform> buttTransforms;
    public List<GameObject> Inputs;
    public GameObject Output;

    public bool hasCollided;

    private void Start()
    {
        BrewPanel.SetActive(false);
        PressE.SetActive(false);
        Crosshair.SetActive(true);
    }

    public bool DoListsMatch(List<GameObject> list1, List<PotionRecipe> list2)
    {
        bool areListsEqual = false;

        if (list1.Count != list2.Count)
            return false;

        if (list1.Count == list2.Count && !areListsEqual)
        {
            list1.Sort();
            list2.Sort();

            for (int i = 0; i < list1.Count; i++)
            {
                if (list2[i] == list1[i])
                {
                    areListsEqual = true;
                }
            }
        }
        return areListsEqual;
    }

    private void Update()
    {
        if (Inputs.Count == 3)
        {
            if (BrewPanel.activeSelf == true)
            {
                if (DoListsMatch(Inputs, Recipes))
                {
                    Debug.Log(Inputs);
                }
            }
        }
        

        if (hasCollided && Input.GetKeyDown(KeyCode.E))
        {
            if (BrewPanel.activeSelf == false)
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

            buttons.Clear();
            Inputs.Clear();

            Time.timeScale = 1;
            foreach (Transform child in lstItems)
            {
                GameObject.Destroy(child.gameObject);
                
            }
        }
    }

    public void AddInput(GameObject input)
    {
        if (Inputs.Count < 3)
        {
            Inputs.Add(input);
        }
    }

    public void CreateBrewItemDisplay()
    {
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            buttons.Add((GameObject)Instantiate(Inventory.Container[i].Item.prefab, lstItems));

            int but = i;

            buttons[i].GetComponent<Button>().onClick.AddListener(() => AddInput(buttons[but]));
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
