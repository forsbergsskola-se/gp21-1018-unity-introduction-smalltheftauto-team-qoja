using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetJO : MonoBehaviour {
    [SerializeField] private Vector3 offset;
    [SerializeField] private float tweenTime = 0.3f;

    private PlayerJO player;

    protected void Start() {
        player = FindObjectOfType<PlayerJO>();
    }

    protected void Update() {
        Vector3 targetPosition = player.transform.position + offset;
       // transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / tweenTime);
        Vector3 movement = (targetPosition - transform.position) * Time.deltaTime / tweenTime;
        transform.Translate(movement);
    }
}