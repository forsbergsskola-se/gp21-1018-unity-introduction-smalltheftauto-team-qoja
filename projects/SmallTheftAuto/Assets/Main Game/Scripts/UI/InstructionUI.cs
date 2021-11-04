using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    public GameObject instructionUI;
    public GameObject pauseMenuUI;
    bool instructionIsOn = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (instructionIsOn)
            {
                pauseMenuUI.GetComponent<PauseMenu>().Resume();
            }
        }
    }
       
}
