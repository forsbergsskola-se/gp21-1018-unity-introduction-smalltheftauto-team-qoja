using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetJO : MonoBehaviour {
    public Vector3 offset;
    private GameObject target;
    
    private void LateUpdate() {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.position = (target.transform.position + offset);
    }
}