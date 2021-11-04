using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Respawn respawn;
    public PlayerMovement playerMovement;
    private static GameManager _instance;
    private bool _isRespawning;

    public int Health => player.Health;

    public int Money
    {
        get => Player.Money;
        set => Player.Money = value;
    }

    public int Score
    {
        get => player.Score;
        set => player.Score = value;
    }

    private void MakeSingleton()
    {
        //This checks if we have a copy of the GameManager and if so, it destroys it
        if (_instance != null)
        {
            Destroy(gameObject);
            
        }
        //If there's no copy, set the instance to this
        else
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
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

    public void RespawnData()
    {
        playerMovement.enabled = true;
        player.Health = respawn.Health;
        Player.Money = respawn.Money/2;
        player.Score = respawn.Score;
        respawn.RespawnPoint();
        respawn.SaveData();
        _isRespawning = false;
    }

    
    private void Respawn()
    {
        playerMovement.enabled = false;
        _isRespawning = true;
        Invoke(nameof(RespawnData), 3);
    }

    public void StartGame() //This is called after button press on first menu, and when unpausing
    {
        SceneManager.LoadScene("MainGameScene");// here we want to remove the first menu
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGameScene");
        Awake();
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


