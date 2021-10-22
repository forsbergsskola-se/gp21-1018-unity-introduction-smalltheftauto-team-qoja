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
    private float timePassed;

    public void Start() {
        timer = gameObject;
        timerText = timer.GetComponent<TextMeshProUGUI>();
        timerText.text = "";
    }

    public void Update() {
        timePassed += Time.deltaTime;
        timerText.text = $"Timer: {timePassed:0.00}s";
    }
}