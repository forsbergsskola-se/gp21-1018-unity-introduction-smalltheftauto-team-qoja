using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool playerDied;
    
    private int money = 10;
    private int score = 10;
    public int Money
    {
        get => money;

        set => money = value;
    }

    public int Score
    {
        get => score;

        set => score = value;
    }

    private void MakeSingleton()
    {
        if (instance != null) //This checks if we have a copy of the GameManager and if so, it destroys it
        {
            Destroy(gameObject);
            
        }
        else //If there's no copy, set the instance to this
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Awake()
    {
        MakeSingleton();
    }
    

    public void LoadScene() //This is called on player death
    {
        SceneManager.LoadScene("MainGameScene"); 
        //DontDestroyOnLoad(instance);
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
    
    public void RestartGame()
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
