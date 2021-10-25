using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerQL : MonoBehaviour
{
    private int health;
    private int money;

    public int Health
    {
        get => health;
        private set
        {
            health = value;
        }
    }
    void Start()
    {
        Health = 2;
        money = 100;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Health--;
        }

        if (Health == 0)
        {
            Debug.Log("Player dies!");
            StartCoroutine(RestartScene());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            money -= 10;
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
