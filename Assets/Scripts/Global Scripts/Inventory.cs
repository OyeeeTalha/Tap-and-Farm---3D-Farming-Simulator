using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject Farm;
    public TextMeshProUGUI coinsText;
    int Count = 0;
    public List<Sprite> PicturesList = new List<Sprite>();
    public List<Button> PositionList = new List<Button>();

    public List<Button> UsedPositionList = new List<Button>();

    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    public Dictionary<string, int> BuyiedItems = new Dictionary<string, int>();
    public int coins;



    void Start(){
        inventory.Add("Shaljam",100);
        inventory.Add("Apples",100);

        BuyiedItems.Add("Shaljam",2);
        BuyiedItems.Add("Wheat",3);

        
        
        InventoryData data = SaveInventory.LoadInventoryData();
        if (data!=null){
            inventory=data.inventory;
            BuyiedItems =data.BuyiedItems;
            coins = data.coins;
            
        }
        else{
        inventory.Add("Shaljam",0);
        inventory.Add("Apples",0);
        
        }
        coins = 2000;
        coinsText.text = "Coins: "+coins.ToString();
        Debug.Log("Shaljam"+inventory["Shaljam"]);
    }

    void Update(){
        SaveInventory.SaveInventoryData(this);
        
    }
   public void ButtonShowInventory()
    {
        foreach (KeyValuePair<string, int> kvp in inventory)
        {
            string key = kvp.Key;
            int value = kvp.Value;
            foreach(Sprite prefab in PicturesList){
                if(prefab.name == key){
                    Button CurrentButton=PositionList[Count];
                    CurrentButton.image.sprite = prefab;
                    CurrentButton.gameObject.SetActive(true);
                    CurrentButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.ToString();
                    CurrentButton.transform.GetChild(1).gameObject.name = key;
                    UsedPositionList.Add(PositionList[Count]);
                    Count++;
                } 
    }
        }
        InventoryUI.SetActive(true);
    }


    public void SeedInventoryShow(){
         foreach (KeyValuePair<string, int> kvp in BuyiedItems)
        {
            string key = kvp.Key;
            int value = kvp.Value;
            foreach(Sprite prefab in PicturesList){
                if(prefab.name == key){
                    if (value > 0){
                    Button CurrentButton=PositionList[Count];
                    CurrentButton.image.sprite = prefab;
                    CurrentButton.gameObject.SetActive(true);
                    CurrentButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.ToString();
                    CurrentButton.transform.GetChild(1).gameObject.name = key;
                    CurrentButton.onClick.RemoveAllListeners();
                    CurrentButton.onClick.AddListener(() => Farm.GetComponent<UI_Interact_Farm>().SeedSelected(CurrentButton));
                    UsedPositionList.Add(PositionList[Count]);
                    Count++;
                } 
                }
    }
        }
        InventoryUI.SetActive(true);
    }

    public void updateCoin(int CoinsToAdd){
        coins += CoinsToAdd;
        coinsText.text = "Coins: "+coins.ToString();

    }

    public void GetBacktoDefault(){
        foreach (Button button in UsedPositionList){
            button.gameObject.SetActive(false);
            button.transform.GetChild(1).gameObject.name = "Placeholder";
        }
        UsedPositionList.Clear();
        Count=0;
        InventoryUI.SetActive(false);
    }

    public void UpdateBuyiedInventory(int price, string item,int quantity){
        BuyiedItems[item] +=quantity;
        coins -=price;
        coinsText.text = "Coins: "+coins.ToString();
    }
}
