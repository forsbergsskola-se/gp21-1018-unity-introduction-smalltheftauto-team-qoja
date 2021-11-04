using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public bool waitingForSeconds;
    public IEnumerator WaitTime(int seconds)
    {
        if (waitingForSeconds == false)
        {
           //condition = true;
            waitingForSeconds = true;
            yield return new WaitForSeconds(seconds);
            //condition = false;
            waitingForSeconds = false; 
        }
        
    }
}
