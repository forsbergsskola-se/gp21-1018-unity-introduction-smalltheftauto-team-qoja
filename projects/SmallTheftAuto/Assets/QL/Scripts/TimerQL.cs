using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerQL : MonoBehaviour
{
    public Text timer;
    private float timePassed;
    void Start()
    {
        this.timer.text = "";
    }
    void Update()
    {
        timePassed += Time.deltaTime;
        timer.text = timePassed.ToString("0.00");
    }
}
