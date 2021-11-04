using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Player player;

    public int Health { get; private set; }

    public int Money { get; private set; }

    public int Score { get; private set; }

    public void Start()
    {
        player = FindObjectOfType<Player>();
        SaveData();
    }
    
    //Sets the players position on the respawn point
    public void RespawnPoint()
    {
        player.transform.position = gameObject.transform.position;
    }

    //Sets the respawn point to the players position
    private void SetRespawnPoint()
    {
        gameObject.transform.position = player.transform.position;
    }

    public void SaveData()
    {
        SetRespawnPoint();
        Health = player.Health;
        Score = player.Score;
        Money = Player.Money;
    }
}
