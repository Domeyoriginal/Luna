using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayBrewInventory : MonoBehaviour
{
    public InventoryObject Inventory;
    public PotionRecipe[] Recipes;

    public GameObject BrewPanel;
    public GameObject PressE;
    public GameObject Crosshair;

    //UI container
    public Transform lstItems;
    
    public List<GameObject> buttons = new List<GameObject>();
    public List<GameObject> potionButtons;

    public List<Transform> buttTransforms;
    public List<GameObject> Inputs;
    public GameObject Output;

    public bool hasCollided;

    private void Start()
    {
        //sets UI + crosshair to default
        BrewPanel.SetActive(false);
        PressE.SetActive(false);
        Crosshair.SetActive(true);
    }


    private void Update()
    {
        //open brewing UI
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
        //close brewing UI
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


    //check for input list and recipe list, if they match
    public bool DoListsMatch(List<GameObject> list1, List<string> list2)
    {
        //match count has to be the same from inputs and recipe
        int matchcount = 0;

        if (list1.Count != list2.Count)
        {
            return false;
        }

        //match count goes up if 2 lists are the same
        for (int i = 0; i < list1.Count; i++)
        {
            if (list2[i] == list1[i].ToString())
            {
                matchcount++;
            }
        }

        //if count is correct return whole method true, if not then return false
        if (matchcount >= 3)
            return true;
        else
            return false;

    }

    //is the input of button
    public void AddInput(GameObject input)
    {
        //adds to input list if there is no 3 inputs
        if (Inputs.Count < 2)
        {
            Inputs.Add(input);
        }
        else
        {
            Inputs.Add(input);

            //once input = 3 and brewing UI is up
            if (BrewPanel.activeSelf == true)
            {
                //check each recipe
                for (int i = 0; i < Recipes.Length; i++)
                {
                    //check if input and recipe is the same.
                    if (DoListsMatch(Inputs, Recipes[i].Materials))
                    {
                        Inputs.Clear();

                        int button = i;

                        potionButtons.Add(Instantiate((GameObject)Recipes[button].Result.prefab, Output.transform));

                        potionButtons[button].GetComponent<Button>().onClick.AddListener(() => Inventory.AddItem(Recipes[button].Result, 1));
                        
                        potionButtons.Clear();
                        
                    }
                }
            }
        }
    }


    //created the buttons and input listenner.
    public void CreateBrewItemDisplay()
    {

        // runs every item in the inventory and adds a button to the brew screen
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            buttons.Add((GameObject)Instantiate(Inventory.Container[i].Item.prefab, lstItems));

            int but = i;

            //adds an input for each button on the brew screen
            buttons[i].GetComponent<Button>().onClick.AddListener(() => AddInput(buttons[but]));
        }
    }

    //trigger for walking up to brewing table object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasCollided = true;
            PressE.SetActive(true);
        }
    }

    //exiting brewing table object
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
