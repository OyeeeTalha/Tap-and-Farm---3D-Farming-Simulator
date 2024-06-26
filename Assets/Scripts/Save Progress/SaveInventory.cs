using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveInventory 
{


    public static void SaveInventoryData(Inventory Inventory)
    {
        // string savePath = Application.persistentDataPath + "/InventoryData.dat";
        string savePath = "D:/FYP/InventoryData.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        InventoryData inventoryData = new InventoryData(Inventory);
        formatter.Serialize(fileStream, inventoryData);
        fileStream.Close();
    }

    public static InventoryData LoadInventoryData()
    {
        // string savePath = Application.persistentDataPath + "/InventoryData.dat";
        string savePath = "D:/FYP/InventoryData.dat";
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);

            InventoryData data = (InventoryData)formatter.Deserialize(fileStream);
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
