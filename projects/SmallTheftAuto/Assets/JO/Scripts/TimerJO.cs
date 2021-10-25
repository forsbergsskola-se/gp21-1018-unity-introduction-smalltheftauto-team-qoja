using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine.UI;

public class TimerJO : MonoBehaviour {
    private static GameObject timer;
    private TextMeshProUGUI timerText;
    private float timeRemainingInSeconds = 90;
    private bool timerIsRunning;

    public void Start() {
        timer = gameObject;
        timerText = timer.GetComponent<TextMeshProUGUI>();
        timerText.text = "";
        timerIsRunning = true;
    }

    public void Update() {
        if (timerIsRunning) {
            if (timeRemainingInSeconds > 0) {
                timeRemainingInSeconds -= Time.deltaTime;
                DisplayTime(timeRemainingInSeconds);
            } else {
                Debug.Log("Time has run out!");
                timeRemainingInSeconds = 0;
                timerIsRunning = false;
                GameManagerJO.RestartGame();
            }
        }
    }

    void DisplayTime(float time) {
        time += 1;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        
       // timerText.text = $"Timer: {timePassed:0.00}s";
        timerText.text = $"Time remaining: {minutes:00} min {seconds:00}s";
    }
}