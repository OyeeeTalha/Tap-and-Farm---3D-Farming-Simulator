using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellInteract : MonoBehaviour
{

    Dictionary<string, int> Ratelist = new Dictionary<string, int>{
        {"Shaljam" , 10},
        {"Apples" , 12}
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
            MainUI.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.name == "Farmer"){
           MainUI.transform.GetChild(1).gameObject.SetActive(false); 
        }
    }

    public void EnterSell(){
        MainUI.transform.GetChild(0).gameObject.SetActive(true);
        MainUI.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void SelectedObjectToSell(Button button){
        ButtonName = button.transform.GetChild(1).name;
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
    }

    public void SellOne(){
        Debug.Log("This Function Called");
        if (inventory.inventory[ButtonName]>0){
        inventory.updateCoin(Price);
        inventory.inventory[ButtonName] -= 1;
        MainUI.gameObject.GetComponent<InventoryShowScript>().UpdateInvetoryValues();
        }
    }

    public void SellAll(){
        if (inventory.inventory[ButtonName]>0){
        inventory.updateCoin(Price*(inventory.inventory[ButtonName]));
        inventory.inventory[ButtonName] = 0;
        MainUI.gameObject.GetComponent<InventoryShowScript>().UpdateInvetoryValues();
        }
    }

    public void Back(){
        MainUI.transform.GetChild(1).gameObject.SetActive(false);
        MainUI.gameObject.GetComponent<InventoryShowScript>().GetBacktoDefault();
    }
}
