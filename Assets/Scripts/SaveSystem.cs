using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void SavePlayer(ThirdPersonMovement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "C:/Users/Domas/Desktop" + "/player.luna";
        FileStream stream = new FileStream(path, FileMode.Create);

        ThirdPersonData data = new ThirdPersonData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ThirdPersonData LoadPlayer()
    {
        string path = "C:/Users/Domas/Desktop" + "/player.luna";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ThirdPersonData data = formatter.Deserialize(stream) as ThirdPersonData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File not found in "+ path);
            Debug.Log("Creating a save File "+ path);
            return null;
        }
    }
}
