using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAllElements : MonoBehaviour
{
    public GameObject panelMod;
    private void Start()
    {
        panelMod = GameObject.FindGameObjectWithTag("PanelModifier");
        panelMod.SetActive(false);
    }

    public void FindSelectedElement()
    {
        var elementSelected = GameObject.FindGameObjectsWithTag("Elemento");

        foreach (var element in elementSelected)
        {
            if (element.GetComponent<ElementModifier>().isSelected)
            {
                element.GetComponent<ElementModifier>().panelModifier = panelMod;
                element.GetComponent<ElementModifier>().SaveElementModification();
                element.GetComponent<ElementModifier>().panelModifier.SetActive(false);
                element.GetComponent<ElementModifier>().isSelected = false;
            }
        }
    }
}
