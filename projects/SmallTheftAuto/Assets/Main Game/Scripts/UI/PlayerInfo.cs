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
        _health = gameManager.Health;
        _money = gameManager.Money;
        _score = gameManager.Score;
        _playerInfo.text = _health +"<br><br>"+_money+"<br><br>"+_score;
    }
}