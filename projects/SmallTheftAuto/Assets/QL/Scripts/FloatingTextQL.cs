using System;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextQL : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 3f);
        transform.localPosition += new Vector3(0, 5f, 0);
    }

    private void Update()
    {
        GetComponent<TextMesh>().fontSize--;
        //Color color = GetComponent<TextMesh>().color ;
        //color.a /= 10;
    }
}
