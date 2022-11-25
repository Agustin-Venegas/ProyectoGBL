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

    [Header("PrefabsPuestos")]
    public List<ElementInstances> elements;
    List<ElementInstances> instancedElements; // esta trackea los objetos a spawnear y resetear

    [Header("Partes")]
    public VisorElementos UI;

    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }

        //pausar el juego
        Time.timeScale = 0;
    }

    //esta funcion comienza la simulacion, poniendole pley a la cosa
    public void StartSimulation()
    {
        Time.timeScale = 1.0f;
        playing = true;
    }

    //esta funcion debe desespawnear y respawnear los objetos en las listas
    public void RestartSimulation()
    {
        playing = false;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
