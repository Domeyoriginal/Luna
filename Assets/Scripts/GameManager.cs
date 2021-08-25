using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<SaveData> onLevelLoaded;

    public ThirdPersonMovement player;
    public SaveData currentSave;

    GameObject lastSelected;
    public string lastSELECTED;

    //Singleton
    public static GameManager Instance;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "SampleScene")
        {
            onLevelLoaded?.Invoke(currentSave);
        }
    }

    public void SavePlayerPosition()
    {
        SaveData(lastSELECTED, new SaveData(player));
    }

    void LoadPlayerPosition()
    {
        SceneManager.LoadScene("SampleScene");
        currentSave = LoadData(lastSELECTED);
    }

    public void SelectSave()
    {
        lastSelected = EventSystem.current.currentSelectedGameObject;
        lastSELECTED = lastSelected.name;
    }

    public void DeleteSave()
    {
        if (File.Exists(Application.dataPath + "/" + lastSELECTED + ".json"))
        {
            DeleteData(lastSELECTED);
        }
        else
        {
            Debug.Log("no save");
        }
    }

    public void CreateSave()
    {
        if (File.Exists(Application.dataPath + "/" + lastSELECTED + ".json"))
        {
            LoadPlayerPosition();
        }
        else
        {
            SavePlayerPosition();
        }
    }

    public static void SaveData(string name, SaveData saveData)
    {
        string json = JsonUtility.ToJson(saveData,true);
        string saveLocation = Application.dataPath + "/" + name + ".json";

        File.WriteAllText(saveLocation, json);

        #region BinaryFormatter
        //BinaryFormatter formatter = new BinaryFormatter();
        //string path = "C:/Users/Domas/Desktop" + "/player.luna";
        //FileStream stream = new FileStream(path, FileMode.Create);

        //ThirdPersonData data = new ThirdPersonData(player);

        //formatter.Serialize(stream, data);
        //stream.Close();
        #endregion
    }

    public static SaveData LoadData(string name)
    {
        string saveLocation = Application.dataPath + "/" + name + ".json";

        string json = File.ReadAllText(saveLocation);
        return JsonUtility.FromJson<SaveData>(json);

        #region BinaryFormatter
        //string path = "C:/Users/Domas/Desktop" + "/player.luna";
        //if (File.Exists(path))
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    FileStream stream = new FileStream(path, FileMode.Open);

        //    ThirdPersonData data = formatter.Deserialize(stream) as ThirdPersonData;
        //    stream.Close();

        //    return data;
        //}
        //else
        //{
        //    Debug.LogError("Save File not found in "+ path);
        //    Debug.Log("Creating a save File "+ path);
        //    return null;
        //}
        #endregion
    }

    public static SaveData DeleteData(string name)
    {
        string saveLocation = Application.dataPath + "/" + name + ".json";

        File.Delete(saveLocation);

        return JsonUtility.FromJson<SaveData>(saveLocation);
    }
}
