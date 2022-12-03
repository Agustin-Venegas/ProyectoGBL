using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveList : MonoBehaviour
{

    [SerializeField]
    List<Objective> objectiveList = new List<Objective>();

    public int completedObjectives;
    public bool completedGoal;

    public float levelPercentageCompleted;
    public int currentObjectiveIndex;
    public TextMeshProUGUI objectiveUIText;

    public void Update()
    {
        objectiveUIText.text = objectiveList[currentObjectiveIndex].objectiveDescription;
    }

    public void IncrementIndexCurrentObjective()
    {
        if (currentObjectiveIndex < objectiveList.Count)
        {
            currentObjectiveIndex++;
        }
    }

    public void checkCompleted() //Comprobar completitud del nivel o meta final
    {
        foreach(var obj in objectiveList)
        {
            if(obj.isCompleted)
            {
                completedObjectives++;
            }
        }

        levelPercentageCompleted = completedObjectives / (objectiveList.Count + 1);

        if(completedObjectives - 1 >= objectiveList.Count)
        {
            completedGoal = true;
        }
    }
  
    public void AddObjective(int maxValue, string description) //Añadir un objetivo nuevo a la lista
    {
        objectiveList.Add(new Objective(description, maxValue));
    }

    public void RemoveObjectiveByDescription(string description) //Eliminar objetivo por descripción
    {
        foreach(var obj in objectiveList)
        {
            if(description == obj.objectiveDescription)
            {
                objectiveList.Remove(obj);
            }
        }
    }

    public void RemoveObjectiveByIndex(int indexToRemove) //Eliminar objetivo por índice en la lista
    {
        objectiveList.RemoveAt(indexToRemove);
    }
}
