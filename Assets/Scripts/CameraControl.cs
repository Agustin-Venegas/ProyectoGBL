using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera c;

    public float scroll = 20;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x>Screen.width- scroll && transform.position.x < 20)
        {
            transform.position += Vector3.right * Time.fixedUnscaledDeltaTime*5f;
        }
        else if (Input.mousePosition.x < scroll && transform.position.x > -20)
        {
            transform.position -= Vector3.right * Time.fixedUnscaledDeltaTime * 5f;
        }
        
        if (Input.mousePosition.y>Screen.height- scroll && transform.position.y < 8)
        {
            transform.position += Vector3.up * Time.fixedUnscaledDeltaTime*5f;
        }
        else if (Input.mousePosition.y < scroll && transform.position.y > -8)
        {
            transform.position -= Vector3.up * Time.fixedUnscaledDeltaTime * 5f;
        }
        

        if (Input.mouseScrollDelta.y < 0 && c.orthographicSize > 4)
        {
            c.orthographicSize = c.orthographicSize + Input.mouseScrollDelta.y * 0.1f;
        }

        if (Input.mouseScrollDelta.y > 0 && c.orthographicSize < 6) 
        {
            c.orthographicSize = c.orthographicSize + Input.mouseScrollDelta.y * 0.1f;
        }
    }
}
