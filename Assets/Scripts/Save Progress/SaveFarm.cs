using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveFarm 
{


    public static void SaveFarmData(FarmState farmstate)
    {
        // string savePath = Application.persistentDataPath + "/FarmData.dat";
        string savePath = "D:/FYP/FarmData.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        FarmData farmData = new FarmData(farmstate);
        formatter.Serialize(fileStream, farmData);
        fileStream.Close();
    }

    public static FarmData LoadFarmData()
    {
        // string savePath = Application.persistentDataPath + "/FarmData.dat";
        string savePath = "D:/FYP/FarmData.dat";
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);

            FarmData data = (FarmData)formatter.Deserialize(fileStream);
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
