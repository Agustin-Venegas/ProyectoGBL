using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esta clase se encarga de guardar las instancias de objetos de la simulacion, spawnearlos y resetear y eso
public class Scene : MonoBehaviour
{
    [Serializable]
    public class ElementInstances
    {
        public ElementInfo Spawnable;
        public Vector2 pos;
    }

    public static Scene Instance;

    [Header("Inicio y Objetivos")]
    public Elemento Inicio;
    public Elemento Fin;

    [Header("PrefabsPuestos")]
    public List<ElementInstances> elements;
    List<GameObject> instancedElements; // esta trackea los objetos a spawnear y resetear, podria ser gameobject?

    [Header("Partes")]
    public VisorElementos UI;

    public bool playing = false;
    public bool editing = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //pausar el juego
        Time.timeScale = 0;

        instancedElements = new List<GameObject>();

        instancedElements.Add(Instantiate(Inicio.gameObject));
        instancedElements.Add(Instantiate(Fin.gameObject));
        Inicio.gameObject.SetActive(false);
        Fin.gameObject.SetActive(false);
    }

    //esta funcion comienza la simulacion, poniendole pley a la cosa, solo si no ha empezado
    public void StartSimulation()
    {
        if (!playing)
        {

            Time.timeScale = 1.0f;
            playing = true;
            editing = false;

        } else
        {
            Time.timeScale = 1.0f;
            playing = true;
        }
    }

    public void PauseSimulation()
    {
        Time.timeScale = 0f;
    }

    //esta funcion debe desespawnear y respawnear los objetos en las listas, solo si ya ha empezado la simulación
    public void RestartSimulation()
    {
        if (!editing)
        {
            editing = true;
            playing = false;
            Time.timeScale = 0f;

            //TODO: Borrar y Resetear
            foreach (GameObject e in instancedElements)
            {
                Destroy(e);
            }

            foreach (ElementInstances e in elements)
            {
                GameObject g = Instantiate(e.Spawnable.prefab);
                g.transform.position = e.pos;
                instancedElements.Add(g);
            }

            Inicio.gameObject.SetActive(true);
            Fin.gameObject.SetActive(true);
            instancedElements.Add(Instantiate(Inicio.gameObject));
            instancedElements.Add(Instantiate(Fin.gameObject));
            Inicio.gameObject.SetActive(false);
            Fin.gameObject.SetActive(false);
        }
    }

    //Pone un elemento a spawnear, con la informacion correspondiente
    public void AddElement(ElementInfo e, Vector2 p)
    {

        ElementInstances i = new ElementInstances();
        i.Spawnable = e;
        i.pos = p;

        elements.Add(i);

        GameObject g = Instantiate(i.Spawnable.prefab);
        g.transform.position = p;
        instancedElements.Add(g);
    }

    //busca y elimina un elemento a spawnear
    public void EraseElement(GameObject g)
    {
        for (int i = 0; i<elements.Count; i++)
        {
            ElementInstances e = elements[i];

            if (g == e.Spawnable.prefab)
            {
                Destroy(g);
                elements.RemoveAt(i);

                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
