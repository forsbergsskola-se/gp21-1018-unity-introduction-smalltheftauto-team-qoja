using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerOK : MonoBehaviour
{
    private float timePassed = 30;
   
    // Update is called once per frame
    void Update()
    {
        timePassed -= Time.deltaTime;
        GetComponent<Text>().text = timePassed.ToString("0m:00s");
        //The getcomponent works because its this object
        //what you get is the component Text
        // then you want to access the text field aka text in Text
        // then you want to set that text field to be the variable timePassed
        //You then want to make the time into a string so it can actually be there, and in the requested format.
        if (timePassed <= 0)
        {
            SceneManager.LoadScene("GameOK");
        }

        

    }
}
