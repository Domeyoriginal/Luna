using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public ScrollRect itemContainer;
    
    public List<GameObject> buttons = new List<GameObject>();
    public List<GameObject> potionButtons;
    public GameObject buttonPressed;

    public GameObject RecipeTransform1;
    public GameObject RecipeTransform2;
    public GameObject RecipeTransform3;

    public List<GameObject> Inputs;
    public GameObject Output;

    public int matchButton;
    public bool hasCollided;

    private void Start()
    {
        matchButton = -1;

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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

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

            //sets the position of the ingredient to the allocated slots for crafting
            if (Inputs.Count == 3)
            {
                input.transform.SetParent(RecipeTransform3.transform);
                input.transform.position = RecipeTransform3.transform.position;
            }

            //once input = 3 and brewing UI is up
            if (BrewPanel.activeSelf == true)
            {
                //check each recipe
                for (int i = 0; i < Recipes.Length; i++)
                {
                    //check if input and recipe is the same.
                    if (DoListsMatch(Inputs, Recipes[i].Materials))
                    {
                        //button for knowing which button is the potion
                        matchButton = i;

                        //adds the potion button to the output area
                        potionButtons.Add(Instantiate((GameObject)Recipes[matchButton].Result.prefab, Output.transform));

                        //adds potion to inventory
                        Inventory.AddItem(Recipes[matchButton].Result, 1);
                        //adds a listener for adding the potion to itemlsit in brewing viewport
                        potionButtons[matchButton].GetComponent<Button>().onClick.AddListener(() => MovePotionToInv());

                        //destroys each input ingredient
                        foreach (GameObject inputs in Inputs)
                        {

                            Destroy(inputs);
                        }

                        //clears all inputs
                        Inputs.Clear();
                    }
                }
            }
        }

        //sets the position of the ingredient to the allocated slots for crafting
        if (Inputs.Count == 1)
        {
            input.transform.SetParent(RecipeTransform1.transform);
            input.transform.position = RecipeTransform1.transform.position;
        }
        else if (Inputs.Count == 2)
        {
            input.transform.SetParent(RecipeTransform2.transform);
            input.transform.position = RecipeTransform2.transform.position;
        }
        
        

    }

    public void MovePotionToInv()
    {
        potionButtons[matchButton].transform.SetParent(lstItems);
        potionButtons[matchButton].transform.position = lstItems.transform.position;
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
