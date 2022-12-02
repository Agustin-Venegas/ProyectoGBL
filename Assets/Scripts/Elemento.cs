using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//esta clase se encarga de representar un elemento que se puede poner en la pantalla
//tiene que tener un objeto tipo info que se puede editar y eso
//spawnea como prefab cuando se hace funcionar un boton con el mouse y eso

public class Elemento : MonoBehaviour
{

    [Header("Partes")]
    public GameObject Activado; //elemento a activar cuando se active, en caso de ser un boton
    public float EnergiaActivacion; //valor energía de activacion


    //esta funcion setea las variables del Patron en este objeto
    public void SetElementInfo(ElementInfo patron)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (Scene.Instance.editing)
        {
            Scene.Instance.UI.Select(this);
        }
    }
}
