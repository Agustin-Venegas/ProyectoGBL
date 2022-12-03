using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{
    public bool isCompleted;
    public int currentCompleted;
    public int maxCompleted;
    public float percentageCompleted;
    public string objectiveDescription;

    public Objective(string Description, int maxValue) //Constructor
    {
        this.maxCompleted = maxValue;
        this.objectiveDescription = Description;
    }
    
    public void IncrementValue() //Incrementar valor al progreso del objetivo
    {
        currentCompleted++;
        percentageCompleted = currentCompleted / maxCompleted;
        if(currentCompleted >= maxCompleted)
        {
            isCompleted = true;
        }
    }

    
}
