using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private static int money = 0;
    public static int Money
    {
        get => money;

        set => money = value;
    }

    private int Score
    {
        get;
        set;
    }

    void Awake()
    {
        Instance = this;
    }
    

    public void LoadScene() //This is called on player death
    {
        SceneManager.LoadScene("MainGameScene"); 
        DontDestroyOnLoad(Instance);
    }

    public void Save() //This is called on save points
    {
        //Here we want to be able to save progress such as quest completion
        //We also want to save how much ammo we have left
        //We also want to save our score
        
        
    }

    public void StartGame() //This is called after button press on first menu, and when unpausing
    {
        // here we want to remove the first menu
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    

    public void Pause() //This is called when we press a pause button
    {
        //We want everything to stop moving, dealing damage, animating
        //We possibly want a pause menu to appear
        
        //Something time.stop related
    }

    public void Unpause() // Called when pressing Unpause button
    {
        //We want time to resume.
        //If we have a pause menu, remove it
    }
}

public enum GameState
{
    //Here we want to have all the different gamestates, like Control screen
    
}
