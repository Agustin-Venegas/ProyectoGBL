using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//esta clase se encarga de obtener todos los elementos de un JSON o algo
//y mostrarlos en un elemento estilo scrollbar
//2 de diciembre: no me gusta pero podemos usar scriptable objects :c

public class VisorElementos : MonoBehaviour
{
    [Header("Partes")]
    public GameObject Camera;
    public GameObject ButtonPrefab;
    public GameObject Canvas;
    public GameObject Blueprint; //elemento a spawnear

    [Header("Elementos")]
    public List<ElementInfo> elements;

    ElementInfo ToSpawn = new ElementInfo();
    GameObject Selected; //elemento seleccionado

    void Start()
    {
        Blueprint.SetActive(false);

        foreach (ElementInfo e in elements)
        {
            Instantiate(ButtonPrefab, Canvas.transform).GetComponent<BotonElemento>().element = e;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = Camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        //eventos de mouse izquierdo (click)
        if (Input.GetMouseButtonDown(0))
        {

            if (Selected != null)
            {
                Selected.transform.position = p;
                Scene.Instance.UpdateElement(Selected);
                Selected = null;
            }

            if (ToSpawn.Name != null)
            {
                Scene.Instance.AddElement(ToSpawn, p);

                ToSpawn = new ElementInfo();
                Blueprint.SetActive(false);
            }
        }

        Blueprint.transform.position = p;
    }

    //selecciona un objeto ya puesto para moverlo,
    public void Select(GameObject e)
    {
        //no seleccionar si es el inicio
        if (e == Scene.Instance.Fin.gameObject || e == Scene.Instance.Inicio.gameObject) return;
        
        Selected = e;

        ToSpawn = new ElementInfo(); //esto deberia borrar
        Blueprint.SetActive(false);
    }

    //selecciona un objeto de la lista de prefabs para ponerlo
    public void SelectSpawn(ElementInfo e)
    {
        if (Selected != null)
        {
            Selected = null;
        }

        ToSpawn = e;
        Blueprint.SetActive(true);
        Blueprint.GetComponent<SpriteRenderer>().sprite = e.sprite;
    }
}
