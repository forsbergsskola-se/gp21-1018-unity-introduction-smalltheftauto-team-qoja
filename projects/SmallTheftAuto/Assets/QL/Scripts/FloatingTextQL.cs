using UnityEngine;

public class FloatingTextQL : MonoBehaviour
{
    private Color temp;
    void Start()
    {
        //Destroy(gameObject, 3f);
        GetComponent<TextMesh>().fontSize = 100;
        transform.localPosition += new Vector3(0, 3f, 0);
        temp = this.gameObject.GetComponent<TextMesh>().color;
        temp.a = 1f;
        this.gameObject.GetComponent<TextMesh>().color = temp;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0.005f, 0);
        temp.a -= Time.deltaTime;
        temp.a = Mathf.Clamp(temp.a, 0f, 1f);
        this.gameObject.GetComponent<TextMesh>().color = temp;
        //Debug.Log(temp.a);
        if(temp.a < 0.01) Destroy(gameObject);
    }

}
