using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameOK : MonoBehaviour
{
    

    public void LoadGame()
    {
        SceneManager.LoadScene("GameOK");
    }
}
