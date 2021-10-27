using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private float timePassed;
    private int timeSecond;
    private float maxTime = 10f;

    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        timePassed = 0;
        timer.enableAutoSizing = true;
    }

    void Update()
    {
        timePassed = Mathf.Clamp(timePassed+Time.deltaTime, 0, maxTime);
        float timeLeft = maxTime - timePassed;
        int timeInMinute = Mathf.FloorToInt(timeLeft / 60);
        int timeInSecond = Mathf.FloorToInt(timeLeft % 60);
        timer.text = timeInMinute + "m" + timeInSecond + "s";
        if (timeLeft == 0)
        {
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
