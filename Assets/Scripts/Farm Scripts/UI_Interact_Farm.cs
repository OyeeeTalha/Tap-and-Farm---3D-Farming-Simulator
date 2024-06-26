using UnityEngine;
using UnityEngine.UI;

public class UI_Interact_Farm : MonoBehaviour
{
    // Start is called before the first frame update

   public GameObject ui;
 public FarmState farmState;
 public GameObject InventoryButton;


    // Update is called once per frame
    void Update()
    {
        if (farmState.State == false){
            
            Timerout();

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Farmer")
        {
            ui.gameObject.SetActive(true);

            if (farmState.plantCheck==true){
                ui.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (farmState.collectCheck==true){
                ui.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
            else{
                ui.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            
        }
    }

    void OnTriggerExit(Collider other){
         if (other.name == "Farmer")
        {
            ui.gameObject.SetActive(false);
            if (farmState.plantCheck==true){
                ui.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (farmState.collectCheck==true){
                ui.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }
            else{
                ui.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
    public void Plant(){
         // -----timer--------
        ui.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        InventoryButton.GetComponent<Inventory>().SeedInventoryShow();
        
       
    }

    public void SeedSelected(Button button){
        farmState.selectedSeed = button.transform.GetChild(1).name;
        farmState.FarmInUse = this.transform.Find(farmState.selectedSeed).gameObject;
        farmState.TotalFarmStates = farmState.FarmInUse.gameObject.transform.childCount;
        farmState.timeAfterStateChange = farmState.seconds/(farmState.TotalFarmStates-1);
        farmState.FarmInUse.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        InventoryButton.GetComponent<Inventory>().GetBacktoDefault();
        ui.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        farmState.startTimer();
        farmState.plantCheck = false;
        InventoryButton.GetComponent<Inventory>().BuyiedItems[farmState.selectedSeed]-=1;
    }
    void Timerout(){
        if (farmState.timer.seconds<0){
            ui.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            ui.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            farmState.State=true;
            farmState.collectCheck=true; 
        }
    }

    public void Collect(){
        ui.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        ui.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        farmState.FarmInUse.gameObject.transform.GetChild(farmState.FarmInUse.gameObject.transform.childCount-1).gameObject.SetActive(false);
        farmState.collectCheck=false;
        farmState.plantCheck = true;
        farmState.currentState =0;
        InventoryButton.GetComponent<Inventory>().inventory[farmState.FarmInUse.name]+= Random.Range(5,10);
        farmState.FarmInUse = null;
        

    }
}
