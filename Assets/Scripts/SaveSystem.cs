using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveSystem : MonoBehaviour
{
    SaveData saveData;
    public ThirdPersonMovement player;

    private void Start()
    {
        LoadPlayerPosition();
    }

    //Need to have this on Main Menu
    public void SavePlayerPosition()
    {
        SaveSystem.SaveData("Luna", new SaveData(player));
    }

    //Need to have this on Main Menu
    public void LoadPlayerPosition()
    {
        SaveData data = SaveSystem.LoadData("Luna");

        if (data == null)
        {
            SavePlayerPosition();
        }
        else
        {
            transform.position = data.playerPosition;
        }
    }


    public static void SaveData(string name , SaveData saveData)
    {
        string json = JsonUtility.ToJson(saveData,true);
        string saveLocation = Application.dataPath + "/" + name + ".json";

        File.WriteAllText(saveLocation,json);

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
        return JsonUtility.FromJson<SaveData> (json);

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
}
