using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAppleTree 
{
    


    public static void SaveAppleTreeData(AppleTreeStateCheck appleTreeStateCheck)
    {
        // string savePath = Application.persistentDataPath + "/AppleTreeData.dat";
        string savePath = "D:/FYP/AppleTreeData.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        AppleTreeData appleTreeData = new AppleTreeData(appleTreeStateCheck);
        formatter.Serialize(fileStream, appleTreeData);
        fileStream.Close();
    }

    public static AppleTreeData LoadAppleTreeData()
    {
        // string savePath = Application.persistentDataPath + "/AppleTreeData.dat";
        string savePath = "D:/FYP/AppleTreeData.dat";
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);

            AppleTreeData data = (AppleTreeData)formatter.Deserialize(fileStream);
            fileStream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("Farm data file not found.");
            return null;
        }
    }
}
