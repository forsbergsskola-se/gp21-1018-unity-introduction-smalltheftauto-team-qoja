using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private TextMeshProUGUI playerInfo;
    private int health;
    private int money;
    private int score;
    public GameObject player;
   // public GameManager gameManager;
    public GameManager gameManager;

    void Awake()
    {
        playerInfo = GetComponent<TextMeshProUGUI>();
        playerInfo.enableAutoSizing = true;
       gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        health = player.GetComponent<Player>().Health;
         money = gameManager.Money;
         score = gameManager.Score;
        // money = Player.Money;
        // score = player.GetComponent<Player>().Score;
        playerInfo.text = health +"<br><br>"+money+"<br><br>"+score;
    }
}
