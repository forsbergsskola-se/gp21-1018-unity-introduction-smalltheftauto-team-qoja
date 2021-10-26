using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private TextMeshProUGUI playerInfo;
    private int health;
    private int money;
    public GameObject player;

    void Start()
    {
        playerInfo = GetComponent<TextMeshProUGUI>();
        playerInfo.enableAutoSizing = true;
    }

    void Update()
    {
        health = player.GetComponent<Player>().Health;
        money = player.GetComponent<Player>().Money;
        playerInfo.text = health +"<br><br>"+money;
        
    }
}
