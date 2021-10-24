using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerProQL : MonoBehaviour
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
        int timeInMinute = Mathf.FloorToInt(timePassed / 60);
        int timeInSecond = Mathf.FloorToInt(timePassed % 60);
        timer.text = "Time passed: "+timeInMinute+"m"+timeInSecond+"s  Time left: " + timeLeft.ToString("0.00")+"s";
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
