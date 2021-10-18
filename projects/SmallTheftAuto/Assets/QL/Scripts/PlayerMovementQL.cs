using UnityEngine;

public class PlayerMovementQL : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 200.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Return -1 to 1 upon the input of "Vertical"(w,s,up,down) or "Horizonal"(a,d,left,down)
        float translation = Input.GetAxis("Vertical") * speed; 
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0f, translation, 0f);
        transform.Rotate(0f,0f,rotation);

        
        // if (Input.GetKey(KeyCode.W)) transform.Translate(0f, 0.01f, 0f);
        // if (Input.GetKey(KeyCode.S)) transform.Translate(0f, -0.01f, 0f);
        // if(Input.GetKey(KeyCode.A)) transform.Rotate(0f, 0f, 1.0f);
        // if(Input.GetKey(KeyCode.D)) transform.Rotate(0f, 0f, -1.0f);
    }
}
