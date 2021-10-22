using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerProQL : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private float timePassed;
    private int timeSecond;
    
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        timePassed = 0;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        
        
        timer.text = timePassed.ToString("0");
    }
}
