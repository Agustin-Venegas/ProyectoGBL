using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

//pone esto en un objeto
public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI disp; //necesita tener un elemento de textmesh pro
    public Image head; //y un sprite de UI
    public string[] Sentences;  //frases, cada imagen acompaña un dialogo
    public Sprite[] TalkingHeads; //imagen q aparece, puede ser null
    public float CharSpeed = 0.025f;

    public GameObject Boton; //boton k avanza el dialogo

    public UnityEvent OnFinish;
    public UnityEvent OnStart;

    int index = 0;
    bool stopped = false;


    Coroutine run;

    IEnumerator Type()
    {
        head.sprite = TalkingHeads[index];

        foreach (char c in Sentences[index].ToCharArray())
        {
            if (!stopped) disp.text += c;
            yield return new WaitForSeconds(CharSpeed);
        }
    }


    //Start is called before the first frame update
    void Start()
    {
        OnStart.Invoke();
    }

    //Update is called once per frame
    void Update()
    {
    }

    void OnEnable()
    {
        run = StartCoroutine(Type());
    }

	//esta funcion puede ponerse en un boton para saltar la animacion o cambiar de dialogo
    public void Avanzar()
    {
        if (disp.text == Sentences[index])
        {
            if (index < Sentences.Length - 1)
            {
                stopped = false;
                index++;
                disp.text = "";
                run = StartCoroutine(Type());
            }
            else
            {
                disp.text = "";
                index = 0;
				OnFinish.Invoke();
            }
        }
        else
        {
            StopCoroutine(run);
            stopped = true;
            disp.text = Sentences[index];
        }
    }
}