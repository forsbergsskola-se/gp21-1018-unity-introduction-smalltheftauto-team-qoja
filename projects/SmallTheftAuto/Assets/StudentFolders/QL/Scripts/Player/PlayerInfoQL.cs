using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInfoQL : MonoBehaviour
{
    private TextMeshProUGUI playerInfo;
    private GameObject player;
    private int health;
    private int money;
    private int score;
    

    void Start()
    {
        playerInfo = GetComponent<TextMeshProUGUI>();
        playerInfo.enableAutoSizing = true;
        player = FindObjectOfType<PlayerMovementQL>().gameObject;
    }

    void Update()
    {
        if (player != null)
        {
            health = player.GetComponent<PlayerQL>().Health;
            money = player.GetComponent<PlayerQL>().Money;
            score = player.GetComponent<PlayerQL>().Score;
            playerInfo.text = "Player health "+health+"<br>Money "+money+"<br>Score "+score;
        }
        
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
