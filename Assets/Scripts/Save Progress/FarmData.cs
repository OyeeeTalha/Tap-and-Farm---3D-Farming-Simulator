using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FarmData
{
    public bool State;

    public int Timer;

    public int currentState;

    public bool plantCheck;
    public bool collectCheck;
    public int timeAfterStateChange;

    public string SeedSelected;

    public FarmData(FarmState farmState){
        State = farmState.State;
        Timer = farmState.timer.seconds;
        currentState = farmState.currentState;
        plantCheck = farmState.plantCheck;
        collectCheck=farmState.collectCheck;
        timeAfterStateChange = farmState.timeAfterStateChange;
        SeedSelected = farmState.selectedSeed;
    }
}

