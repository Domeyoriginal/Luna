using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveSystem : MonoBehaviour
{
    public ThirdPersonMovement player;

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
