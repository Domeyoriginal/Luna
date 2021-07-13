using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayBrewInventory : MonoBehaviour
{
    public InventoryObject Inventory;
    public PotionRecipe[] Recipes;
    public int potionCrafting;

    public GameObject BrewPanel;
    public GameObject PressE;
    public GameObject Crosshair;

    public Transform lstItems;
    public List<GameObject> buttons = new List<GameObject>();

    public List<Transform> buttTransforms;
    public List<GameObject> Inputs;
    public GameObject Output;

    public bool hasCollided;
    public bool crafting = false;



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

    public bool DoListsMatch(List<GameObject> list1, List<string> list2)
    {
        int matchcount = 0;

        if (list1.Count != list2.Count)
        {
            return false;
        }

        //list1.Sort(
        //    delegate (GameObject i1, GameObject i2)
        //    {
        //        return i1.GetComponent<ItemObject>().Name.CompareTo(i2.name);
        //    }
        //    );
        //list2.Sort();

        for (int i = 0; i < list1.Count; i++)
        {
            if (list2[i] == list1[i].ToString())
            {
                matchcount++;
            }
        }

        if (matchcount >= 3)
            return true;
        else
            return false;

    }

    public void AddInput(GameObject input)
    {
        if (Inputs.Count < 2)
        {
            Inputs.Add(input);
        }
        else
        {
            Inputs.Add(input);

            if (BrewPanel.activeSelf == true)
            {
                //Debug.Log("brew actve");

                for (int i = 0; i < Recipes.Length; i++)
                {
                    if (DoListsMatch(Inputs, Recipes[i].Materials))
                    {
                        //Debug.Log("Lists match");
                        Inputs.Clear();
                    }
                }
            }
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
