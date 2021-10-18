using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementJO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Translate(0f, 0.01f, 0f);
        }
    }
}
