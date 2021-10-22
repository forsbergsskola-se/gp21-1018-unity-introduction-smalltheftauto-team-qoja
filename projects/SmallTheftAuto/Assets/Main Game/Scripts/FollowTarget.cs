using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    //public Transform target;
    public Vector3 offset;
    private GameObject target;
    private void Start()
    {
       
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.position = (target.transform.position + offset);
    }
}