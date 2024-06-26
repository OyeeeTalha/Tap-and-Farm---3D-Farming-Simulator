using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryShowScript : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject Inventory;

    int Count=0;
    public List<Sprite> PicturesList = new List<Sprite>();
    public List<Button> PositionList = new List<Button>();

    public List<Button> UsedPositionList = new List<Button>();

    public GameObject BuyShop;

    public GameObject SellShop;

    BuyInteract buyInteract;
    SellInteract sellInteract;

    // Update is called once per frame
    void Start(){
        buyInteract = BuyShop.gameObject.GetComponent<BuyInteract>();
        sellInteract = SellShop.gameObject.GetComponent<SellInteract>();
    }
    public void loadInventory(){
        foreach (KeyValuePair<string, int> kvp in MainUI.gameObject.GetComponent<Inventory>().inventory)
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
                    CurrentButton.onClick.RemoveAllListeners();
                    Debug.Log("Count = "+ Count);
                    PositionList[Count].onClick.AddListener(() => sellInteract.SelectedObjectToSell(CurrentButton));
                    UsedPositionList.Add(PositionList[Count]);
                    Count++;
                } 
    }
        }
        Inventory.SetActive(true);
    }



    public void BuyloadInventory(){
        foreach (KeyValuePair<string, int> kvp in BuyShop.gameObject.GetComponent<BuyInteract>().Ratelist)
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
                    CurrentButton.onClick.RemoveAllListeners();
                    CurrentButton.onClick.AddListener(() => buyInteract.SelectedObjectToBuy(CurrentButton));
                    UsedPositionList.Add(PositionList[Count]);
                    Count++;
                } 
    }
        }
        Inventory.SetActive(true);
    }

    public void GetBacktoDefault(){
        foreach (Button button in UsedPositionList){
            button.gameObject.SetActive(false);
            button.transform.GetChild(1).gameObject.name = "Placeholder";
        }
        UsedPositionList.Clear();
        Count=0;
    }

    public void UpdateInvetoryValues(){
        foreach (KeyValuePair<string, int> kvp in MainUI.gameObject.GetComponent<Inventory>().inventory)
        {
            string key = kvp.Key;
            int value = kvp.Value;
            
            foreach (Button button in UsedPositionList){
                if (button.transform.GetChild(1).gameObject.name == key){
                    button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.ToString();
            }
        }
        }
    }


    public void UpdateBuyInvetoryValues(){
        foreach (KeyValuePair<string, int> kvp in BuyShop.gameObject.GetComponent<BuyInteract>().Ratelist)
        {
            string key = kvp.Key;
            int value = kvp.Value;
            Debug.Log(key+value);
            
            foreach (Button button in UsedPositionList){
                if (button.transform.GetChild(1).gameObject.name == key){
                    button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.ToString();
            }
        }
        }
    }
}
