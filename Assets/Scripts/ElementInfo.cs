using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esta clase se encarga de guardar informacion de elementos estatica (no de instancia)
//el proposito es que aparezca esta info en el visor y luego instanciar esa info en los elementos
[Serializable]
public struct ElementInfo
{
    /*public ElementInfo()
    {
        Name = string.Empty;
        ActivationEnergy = 0;
        sprite = null;
        prefab = null;
    }
    */

    public string Name;
    public float ActivationEnergy;
    public Sprite sprite;
    public GameObject prefab;
}