using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeStateCheck : MonoBehaviour
{
    public bool State = true;
    
    public Timer timer;
    public int seconds;
    private bool LaodData=false;

    public bool CollectState = true; 
    // Start is called before the first frame update
    void Start()
    {
        AppleTreeData data = SaveAppleTree.LoadAppleTreeData();
        if (data != null){
            LaodData = true;
            State = data.State;
            Debug.Log("apple time remaining "+data.timer);
            if (data.timer > 0){
                timer.StartStopwatch(data.timer);
                CollectState = false;
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(true);
            }
            else{
                CollectState =true;
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(false);
            }
            

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveAppleTree.SaveAppleTreeData(this);
        
    }
}
