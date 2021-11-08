using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameManager gameManager;
    private TextMeshProUGUI _playerInfo;
    private int _health;
    private int _money;
    private int _score;

    void Awake()
    {
        _playerInfo = GetComponent<TextMeshProUGUI>();
        _playerInfo.enableAutoSizing = true;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Why is this not done with properties in gameManager instead? That way you can update the text only if the players stats are changed instead of every frame. :)
        _health = gameManager.Health;
        _money = gameManager.Money;
        _score = gameManager.Score;
        _playerInfo.text = _health +"<br><br>"+_money+"<br><br>"+_score;
    }
}