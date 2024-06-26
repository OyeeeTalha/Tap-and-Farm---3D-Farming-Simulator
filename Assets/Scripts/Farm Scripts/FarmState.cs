using UnityEngine;

public class FarmState : MonoBehaviour
{
     public bool State = true;
    
    public Timer timer;
    public int seconds=18;

    public GameObject FarmInUse;

    public int TotalFarmStates;

    public int timeAfterStateChange;

    public int currentState = 0;


    public bool plantCheck = true;
    public bool collectCheck = false;

    public string selectedSeed;

    void Start()
    {
        FarmData data = SaveFarm.LoadFarmData();
        if (data != null){
             State = data.State;

             currentState = data.currentState;

             plantCheck = data.plantCheck;
             collectCheck=data.collectCheck;
             timeAfterStateChange = data.timeAfterStateChange;
             selectedSeed = data.SeedSelected;
             FarmInUse = this.transform.Find(selectedSeed).gameObject;
             TotalFarmStates = FarmInUse.gameObject.transform.childCount;
             Debug.Log("CurrentState = "+currentState + "TotalFarmStates = "+selectedSeed);
             if (currentState==-1){
                FarmInUse.gameObject.transform.GetChild(TotalFarmStates-1).gameObject.SetActive(true);
             }
             else{
             FarmInUse.gameObject.transform.GetChild(currentState).gameObject.SetActive(true);
             }
             if (plantCheck==true){
                FarmInUse.gameObject.transform.GetChild(currentState).gameObject.SetActive(false);
             }
             if (data.Timer > 0){
                timer.StartStopwatch(data.Timer);
                InvokeRepeating("stateUpdate",data.Timer%timeAfterStateChange,timeAfterStateChange);
             }
        } 
        
        
    }

    void Update(){
        SaveFarm.SaveFarmData(this);
    }

    public void startTimer(){
        timer.StartStopwatch(seconds);
        InvokeRepeating("stateUpdate",timeAfterStateChange,timeAfterStateChange);

        
    }

    void stateUpdate(){
        currentState ++;
        FarmInUse.gameObject.transform.GetChild(currentState).gameObject.SetActive(true);
        FarmInUse.gameObject.transform.GetChild(currentState-1).gameObject.SetActive(false);

        if (currentState == TotalFarmStates-1){
            CancelInvoke("stateUpdate");
            State = false;
            currentState=-1;
        }

    }
}
