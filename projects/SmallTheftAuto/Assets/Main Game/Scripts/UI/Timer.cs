using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float MAXTime;
    public static float TimePassed;
    public static bool TimeIsOut;
    private TextMeshProUGUI _timer;
    private float _timeLeft;

    void Start()
    {
        _timer = GetComponent<TextMeshProUGUI>();
        _timer.enableAutoSizing = true;
    }
  
    void Update()
    {
        if (!TimeIsOut)
        {
            TimePassed = Mathf.Clamp(TimePassed + Time.deltaTime, 0, MAXTime);
            _timeLeft = MAXTime - TimePassed;
            int timeInMinute = Mathf.FloorToInt(_timeLeft / 60);
            int timeInSecond = Mathf.FloorToInt(_timeLeft % 60);
            _timer.text = timeInMinute + "m" + timeInSecond + "s";
            
            if (_timeLeft == 0)
            {
                TimeIsOut = true;
            }
        }
    }
}
