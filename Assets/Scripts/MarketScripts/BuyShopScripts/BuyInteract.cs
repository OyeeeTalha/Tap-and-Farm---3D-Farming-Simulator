using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyInteract : MonoBehaviour
{

    public Dictionary<string, int> Ratelist = new Dictionary<string, int>{
        {"Shaljam" , 100},
        {"wheat" , 120}
    };
    bool buttonActive = false;
    Button ActiveButton = null;
    int Price;
    string ButtonName;
    Inventory inventory;
    public GameObject MainUI;
    void Start(){
     inventory= MainUI.gameObject.GetComponent<Inventory>();
    }
    void OnTriggerEnter(Collider other){
        if (other.name == "Farmer"){
            MainUI.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.name == "Farmer"){
           MainUI.transform.GetChild(2).gameObject.SetActive(false); 
        }
    }

    public void EnterBuy(){
        MainUI.transform.GetChild(0).gameObject.SetActive(true);
        MainUI.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void SelectedObjectToBuy(Button button){
        ButtonName = button.transform.GetChild(1).name;
        Debug.Log(button.name);
        Price = Ratelist[ButtonName];
        if (ActiveButton != null){
            ActiveButton.transform.GetChild(2).gameObject.SetActive(false);
            button.transform.GetChild(2).gameObject.SetActive(true);
            ActiveButton=button;
        }
        if (buttonActive == false){
            button.transform.GetChild(2).gameObject.SetActive(true);
            ActiveButton = button;
            buttonActive=true;
        }
        else{
            button.transform.GetChild(2).gameObject.SetActive(false);
            ActiveButton = null;
            buttonActive=false;
        }
        Button ActionAdd = ActiveButton.transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Button>();
        ActionAdd.onClick.RemoveAllListeners();
        ActionAdd.onClick.AddListener(() => this.BuyOne());
        ActionAdd = ActiveButton.transform.GetChild(2).transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Button>();
        ActionAdd.onClick.RemoveAllListeners();
        ActionAdd.onClick.AddListener(() => this.Buyten());
    }

    public void BuyOne(){
        
        if (inventory.coins>Price){
        inventory.UpdateBuyiedInventory(Price,ButtonName,1);
        MainUI.gameObject.GetComponent<InventoryShowScript>().UpdateBuyInvetoryValues();
        }
    }

    public void Buyten(){
        if (inventory.coins>Price*10){
        inventory.UpdateBuyiedInventory(Price*10,ButtonName,1);
        MainUI.gameObject.GetComponent<InventoryShowScript>().UpdateBuyInvetoryValues();
        }
    }

    public void Back(){
        MainUI.transform.GetChild(1).gameObject.SetActive(false);
        MainUI.gameObject.GetComponent<InventoryShowScript>().GetBacktoDefault();
    }
}
