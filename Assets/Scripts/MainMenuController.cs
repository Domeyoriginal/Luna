using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // UI Panels
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
