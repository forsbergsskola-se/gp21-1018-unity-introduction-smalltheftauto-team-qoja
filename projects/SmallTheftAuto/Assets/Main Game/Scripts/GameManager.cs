using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //[SerializeField] private GameObject player;
    public Player player;
    public Respawn respawn;
    

    public bool playerDied;
    
    // private int money = 10;
    // private int score = 10;
    // private int health = 100;

    public int Health
    {
        get => player.Health;
        set => player.Health = value;

    }
    public int Money
    {
        get => player.Money;

        set => player.Money = value;
    }

    public int Score
    {
        get => player.Score;

        set => player.Score = value;
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
        player = FindObjectOfType<Player>();
        respawn = FindObjectOfType<Respawn>();
        MakeSingleton();
    }

    private void Update()
    {
        if (player.IsDead)
        {
            Respawn();
        }
    }


    public void LoadScene() //This is called on player death
    {
        SceneManager.LoadScene("MainGameScene");
        Time.timeScale = 1;
        //DontDestroyOnLoad(instance);
    }

    public void Save() //This is called on save points
    {
        //Here we want to be able to save progress such as quest completion
        //We also want to save how much ammo we have left
        //We also want to save our score
        
        
    }

    public void Respawn()
    {
    
        player.Health = respawn.health;
        //player.Money = respawn.money / 2;
        player.Money = player.Money / 2;
        player.Score = respawn.score;
        respawn.RespawnPoint();
        //respawn.LoadData();
    }

    public void StartGame() //This is called after button press on first menu, and when unpausing
    {
        // here we want to remove the first menu
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGameScene");
        player.Health = player.maxHealth;
    }
    

    public void Pause() //This is called when we press a pause button
    {
        Time.timeScale = 0; //This pauses time, but sound does not stop.
        //We want everything to stop moving, dealing damage, animating
        //We possibly want a pause menu to appear

        //Something time.stop related
    }

    public void Unpause() // Called when pressing Unpause button
    {
        Time.timeScale = 1;
        //We want time to resume.
        //If we have a pause menu, remove it
    }
}

public enum GameState
{
    //Here we want to have all the different gamestates, like Control screen
    
}
