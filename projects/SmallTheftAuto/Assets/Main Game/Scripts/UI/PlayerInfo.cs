using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private TextMeshProUGUI playerInfo;
    private int health;
    private int money;
    private int score;
    public GameObject player;

    void Start()
    {
        playerInfo = GetComponent<TextMeshProUGUI>();
        playerInfo.enableAutoSizing = true;
    }

    void Update()
    {
        health = player.GetComponent<Player>().Health;
        money = GameManager.instance.Money;
        score = GameManager.instance.Score;
        // money = Player.Money;
        // score = player.GetComponent<Player>().Score;
        playerInfo.text = health +"<br><br>"+money+"<br><br>"+score;
    }
}
