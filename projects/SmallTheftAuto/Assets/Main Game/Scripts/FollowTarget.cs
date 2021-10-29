using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float tweenTime = 0.3f;

    private Player player;

    protected void Start() {
        player = FindObjectOfType<Player>();
    }

    protected void LateUpdate() {
        Vector3 targetPosition = player.transform.position + offset;
        Vector3 movement = (targetPosition - transform.position) * Time.deltaTime / tweenTime;
        transform.Translate(movement);
    }
    
    //if player deactivated target becomes car
}