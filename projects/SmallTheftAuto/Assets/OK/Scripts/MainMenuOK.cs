using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOK : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenu.activeInHierarchy)
            {
                mainMenu.SetActive(false);
            }
            else mainMenu.SetActive(true);
        }
    }
}
