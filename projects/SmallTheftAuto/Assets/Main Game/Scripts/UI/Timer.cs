using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private float timeLeft;
    public static float maxTime;
    public static float timePassed;
    public static bool timeIsOut;

    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        timer.enableAutoSizing = true;
    }
  
    void Update()
    {
        if (!timeIsOut)
        {
            timePassed = Mathf.Clamp(timePassed+Time.deltaTime, 0, maxTime);
            timeLeft = maxTime - timePassed;
            int timeInMinute = Mathf.FloorToInt(timeLeft / 60);
            int timeInSecond = Mathf.FloorToInt(timeLeft % 60);
            timer.text = timeInMinute + "m" + timeInSecond + "s";
            if (timeLeft == 0)
            {
                timeIsOut = true;
            }
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
