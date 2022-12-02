using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Esta clase se encarga de que, al apretar el boton, se pueda spawnear un nuevo elemento
public class BotonElemento : MonoBehaviour
{

    ElementInfo info;
    public ElementInfo element { get { return info; } set { info = value; text.text = info.Name; image.sprite = info.sprite; } }
    public Text text;
    public Image image;

    public void SpawnThis()
    {
        Scene.Instance.UI.SelectSpawn(element);
    }
}
