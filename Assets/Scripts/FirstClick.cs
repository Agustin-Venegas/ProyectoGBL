using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstClick : MonoBehaviour
{

    public List<GameObject> Set;
    public UnityEvent OnFinish;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        Set[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Avanzar()
    {
        Set[i].SetActive(false);
        i++;
        if (i >= Set.Count) 
        {
            OnFinish.Invoke();
            Destroy(gameObject);
            return; 
        }

        Set[i].SetActive(true);
    }
}
