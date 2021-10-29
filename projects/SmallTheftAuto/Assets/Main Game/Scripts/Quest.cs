using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Quest : MonoBehaviour
{
    public GameObject questUI;
    public GameObject timerUI;
    public GameObject money;
    public GameObject player;
    public GameObject missionComplete;
    public GameObject missionFailed;
    private bool missionDone;
    public static int missionIndex;
    private int originalMoney;
    public GameManager gameManager;
    public Respawn respawn;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        respawn = FindObjectOfType<Respawn>();
    }

    void Update()
    {
        if(!Player.questIsActive) originalMoney = gameManager.Money;
        if (missionIndex == 0)
        {
            QuestTimer(100);
            if(timerUI.activeSelf) MoneyFinder();

            // Checks if the winning condition is met
            if (gameManager.Money - originalMoney >= 200 && missionDone!=true)
            {
                missionComplete.SetActive(true);
                missionDone = true;
                gameManager.Score += 20;
                respawn.gameObject.transform.position = this.player.transform.position;
                respawn.SaveData();

            }
        
            if (timerUI.activeSelf)
            {
                //Debug.Log(timerUI.GetComponent<Timer>().timeLeft);
                if(Timer.timeIsOut)
                {
                    missionFailed.SetActive(true);
                    missionDone = true;
                }
            }
        
            if (missionDone)
            {
                Invoke("setMissionFalse", 3f);
                missionIndex++;
                Player.questIsActive = false;
                timerUI.SetActive(false);
                Timer.timeIsOut = false;
            }
        }
        
        if (missionIndex == 1)
        {
            missionDone = false;
            if (Input.GetKeyDown(KeyCode.Q) && Player.questIsActive)
            {
                QuestTimer(5);
            }
            if(timerUI.activeSelf) MoneyFinder();
            if (gameManager.Money - originalMoney >= 300 && missionDone!=true)
            {
                missionComplete.SetActive(true);
                missionDone = true;
                gameManager.Score += 20;
            }
            if (timerUI.activeSelf)
            {
                if (Timer.timeIsOut)
                {
                    missionFailed.SetActive(true);
                    missionDone = true;
                }
            }
            if (missionDone)
            {
                Invoke("setMissionFalse", 3f);
                missionIndex++;
                timerUI.SetActive(false);
                Timer.timeIsOut = false;
                Player.questIsActive = false;
            }
        }
    }

    private void QuestTimer(float maximumTime)
    {
        if (Input.GetKeyDown(KeyCode.Q) && Player.questIsActive)
        {
            questUI.SetActive(false);
            timerUI.SetActive(true);
            Timer.maxTime = maximumTime;
            Timer.timePassed = 0;
        }
    }

    void MoneyFinder()
    {
        if (Input.GetKeyDown(KeyCode.E) && Player.questIsActive)
        {
            Money[] moneys = FindObjectsOfType<Money>();
            if (moneys.Length != 0)
            {
                float[] distances = new float[moneys.Length];
                for (int i = 0; i < moneys.Length; i++)
                {
                    distances[i] = Vector3.Distance(player.transform.position, moneys[i].transform.position);
            
                }
                int index = FindMin(distances);
                if (distances[index] < 3)
                {
                    money = moneys[index].gameObject;
                    money.SetActive(false);
                    gameManager.Money += 100;
                }
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
        missionFailed.SetActive(false);
    }
}
