using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameManager gameManager;

    // UI Panels
    public GameObject FirstWindow;
    public GameObject SaveCreate;
    public GameObject DemoMessage;

    private void Start()
    {
        DemoMessage.SetActive(true);
        FirstWindow.SetActive(false);
        SaveCreate.SetActive(false);
    }

    public void StartGame()
    {
        DemoMessage.SetActive(false);
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
