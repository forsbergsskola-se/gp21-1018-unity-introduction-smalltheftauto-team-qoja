using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealthQL : MonoBehaviour
{
    private TextMeshProUGUI playerHealth;
    private int maxHealth;
    private int health;

    void Start()
    {
        playerHealth = GetComponent<TextMeshProUGUI>();
        maxHealth = 2;
        health = maxHealth;
        playerHealth.enableAutoSizing = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            health--;
        }

        if (health == 0)
        {
            Debug.Log("Player dies!");
            StartCoroutine(RestartScene());
        }
        playerHealth.text = "Player health " + health;
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
