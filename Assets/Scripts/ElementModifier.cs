using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementModifier : MonoBehaviour
{
    public GameObject panelModifier;
    GameObject ScaleSlider;
    GameObject RotateSlider;

    public bool isSelected;

    public void OnMouseDown()
    {
        panelModifier = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FindAllElements>().panelMod;
        panelModifier.SetActive(true);
        ScaleSlider = GameObject.FindGameObjectWithTag("ScaleSlider");
        RotateSlider = GameObject.FindGameObjectWithTag("RotateSlider");

        isSelected = true;
        if (this.gameObject.GetComponent<Elemento>())
        {
            Debug.Log("HasElement");
        }

        ScaleSlider.GetComponent<Slider>().value = this.gameObject.transform.localScale.x;
        RotateSlider.GetComponent<Slider>().value = this.gameObject.transform.rotation.z;
    }

    public void SaveElementModification()
    {

        this.gameObject.transform.localScale = new Vector3(ScaleSlider.GetComponent<Slider>().value, ScaleSlider.GetComponent<Slider>().value, ScaleSlider.GetComponent<Slider>().value);
        this.gameObject.transform.rotation = new Quaternion(0, 0, RotateSlider.GetComponent<Slider>().value, 0);
    }


}
