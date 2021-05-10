using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public ThirdPersonMovement player;

    public GameObject FirstWindow;
    public GameObject SaveCreate;

    public GameObject lastSelected;

    private void Start()
    {
        FirstWindow.SetActive(true);
        SaveCreate.SetActive(false);
    }

    public void CreateWorldScreen()
    {
        FirstWindow.SetActive(false);
        SaveCreate.SetActive(true);
    }

    public void BackToMain()
    {
        FirstWindow.SetActive(true);
        SaveCreate.SetActive(false);
    }

    public void SelectSave()
    {
        lastSelected = EventSystem.current.currentSelectedGameObject;
    }

    public void CreateSave()
    {
        if (File.Exists(Application.dataPath + "/" + lastSelected.name + ".json"))
        {
            Debug.Log(Application.dataPath + "/" + lastSelected.name + ".json");
        }
        else 
        {
            SavePlayerPosition();
        }
    }

    public void SavePlayerPosition()
    {
        SaveSystem.SaveData(lastSelected.name, new SaveData(player));
    }

    public void LoadPlayerPosition()
    {
        
    }
}
