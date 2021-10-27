using System;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questContent = "Go kill people!";
    public GameObject questUI;
    public GameObject timerUI;
    public GameObject money;
    public GameObject player;
    public GameObject missionComplete;
    private bool missionDone;
    void Start()
    {
        
    }

    void Update()
    {
        // Print a message on the screen under the timer to show the objective of the quest - Implemented as UI
        
        
        // The timer starts - It has to be implemented as UI
        
        if (Input.GetKeyDown(KeyCode.Q) && Player.questIsActive)
        {
            questUI.SetActive(false);
            timerUI.SetActive(true);
        }
        
        
        MoneyFinder();
        
        
        // Checks if the winning condition is met

        if (Player.Money >= 200 && missionDone!=true)
        {
            timerUI.SetActive(false);
            // Set a new quest up
            missionComplete.SetActive(true);
            missionDone = true;

        }

        if (missionDone)
        {
            Invoke("setMissionFalse", 3f);
        }
        
        
        
        // Checks if the timer is zero - then announces the player as loser
        
        
    }
    
    void MoneyFinder()
    {
        if (Input.GetKeyDown(KeyCode.E) && Player.questIsActive)
        {
            Money[] moneys = FindObjectsOfType<Money>();
            Debug.Log(moneys.Length);
            float[] distances = new float[moneys.Length];
            for (int i = 0; i < moneys.Length; i++)
            {
                distances[i] = Vector3.Distance(player.transform.position, moneys[i].transform.position);
                
            }
            int index = FindMin(distances);
            Debug.Log(distances[index]);
            if (distances[index] < 3)
            {
                //Debug.Log("Go kill people!");
                money = moneys[index].gameObject;
                money.SetActive(false);
                Player.Money += 100;

            }
            
        }
        
    }
    
    public int FindMin(float[] distancesToMoney)
    {
        int indexOfClosestMoney = 0;
        float closestPosition = 1000f;
        
        for(int i = 0; i < distancesToMoney.Length; i++)
        {
            if (distancesToMoney[i] < closestPosition)
            {
                closestPosition = distancesToMoney[i];
                indexOfClosestMoney = i;
            }
        }
        
        return indexOfClosestMoney;
    }

    void setMissionFalse()
    {
        missionComplete.SetActive(false);
    }
}
