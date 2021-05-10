using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public GameObject FirstWindow;
    public GameObject SaveCreate;

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
}
