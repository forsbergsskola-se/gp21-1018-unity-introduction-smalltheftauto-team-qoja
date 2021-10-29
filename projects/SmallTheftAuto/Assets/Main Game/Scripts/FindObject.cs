using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FindObject : MonoBehaviour
{
   public static int FindIndexOfClosestObject(float[] distances)
    {
        int indexOfClosestObject = 0;
        float closestPosition = 1000f;
        for(int i = 0; i < distances.Length; i++)
        {
            if (distances[i] < closestPosition)
            {
                closestPosition = distances[i];
                indexOfClosestObject = i;
            }
        }
        
        return indexOfClosestObject;
    }
    
}
