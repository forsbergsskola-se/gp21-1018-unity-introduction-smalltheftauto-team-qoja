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
    public GameObject wasted;
    public PlayerMovement playerMovement;

    private bool _isRespawning;
    

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
            DontDestroyOnLoad(instance);
        }
    }

    void Awake()
    {
        player = FindObjectOfType<Player>();
        playerMovement = player.GetComponent<PlayerMovement>();
        respawn = FindObjectOfType<Respawn>();
        MakeSingleton();
    }

    private void Update()
    {
        if (player.IsDead && !_isRespawning)
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

    public void RespawnData() //This manages all the respawn variables
    {
        playerMovement.enabled = true;
        player.Health = respawn.Health;
        player.Money = respawn.Money/2;
        player.Score = respawn.Score;
        respawn.RespawnPoint();
        respawn.SaveData();
        _isRespawning = false;
    }

    public void Respawn() //This calls the respawndata function after 3 seconds
    {
        
        //wasted.SetActive(true);
        //Invoke("DisableWasted", 3);
        playerMovement.enabled = false;
        _isRespawning = true;
        Invoke("RespawnData", 3);
        
        //player.Money = player.Money / 2;
    }

    public void StartGame() //This is called after button press on first menu, and when unpausing
    {
        SceneManager.LoadScene("MainGameScene");// here we want to remove the first menu
    }
    
    public void RestartGame()
    {
       
        SceneManager.LoadScene("MainGameScene");
        Awake(); //**IMPORTANT** This fixed the problem
        
        player.Health = player.maxHealth;
    }
    

    public void Pause() //This is called when we press a pause button
    {
        
        Time.timeScale = 0; //This Pauses time
        AudioListener.pause = true; // This pauses the Audio Listener
    }

    public void Unpause() // Called when pressing Unpause button
    {
        Time.timeScale = 1; //This Unpauses time
        AudioListener.pause = false; // This unpauses the Audio Listener
    }
}

public enum GameState
{
    //Here we want to have all the different gamestates, like Control screen
    
}


