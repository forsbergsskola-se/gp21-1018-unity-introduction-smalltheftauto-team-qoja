using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetOK : MonoBehaviour
{
   //public Transform target;
   public Vector3 offset;

   public GameObject target;
   private void Start()
   {
       
   }

   private void Update()
   {
       target = GameObject.FindGameObjectWithTag("Player");
       transform.position = (target.transform.position + offset);
   }
}
