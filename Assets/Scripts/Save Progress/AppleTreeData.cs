using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AppleTreeData
{
    public bool State;
    
    public int timer;

    public AppleTreeData(AppleTreeStateCheck appleTreeStateCheck){
        State = appleTreeStateCheck.State;
        timer = appleTreeStateCheck.timer.seconds;
    }
}
