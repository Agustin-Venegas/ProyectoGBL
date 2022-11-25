using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//esta clase se encarga de obtener todos los elementos de un JSON
//y mostrarlos en un elemento estilo scrollbar
public class VisorElementos : MonoBehaviour
{
    [Header("Partes")]
    public GameObject ButtonPrefab;
    public GameObject Canvas;


    //elemento seleccionado
    Elemento Selected;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //eventos de mouse izquierdo (click)
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    public void Select(Elemento e)
    {
        Selected = e;
    }
}
