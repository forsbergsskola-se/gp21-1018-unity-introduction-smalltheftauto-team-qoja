using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Quest : MonoBehaviour
{
    public GameObject questUI;
    public GameObject timerUI;
    public GameObject player;
    public GameObject missionComplete;
    public GameObject missionFailed;
    public GameObject money;
    private bool missionIsOver;
    public static int missionIndex;
    private int originalMoney;
    public GameManager gameManager;
    public Respawn respawn;
    public static string[] quests = {"Collect 200 dollars", "Collect 100 dollars"};
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
            if (timerUI.activeInHierarchy) MoneyFinder();
            if (gameManager.Money - originalMoney >= 200 && !missionIsOver)
            {
                MissionComplete(20, 100);
            }
            MissionFailed();
            MissionOver();
            if(missionIsOver) originalMoney = gameManager.Money;
        }
        
        if (missionIndex == 1)
        {
            missionIsOver = false;
            QuestTimer(5);
            if(timerUI.activeInHierarchy) MoneyFinder();
            if (gameManager.Money - originalMoney >= 100 && !missionIsOver)
            {
                MissionComplete(20,100);
            }
            MissionFailed();
            MissionOver();
        }
    }

    private void MissionComplete(int addScore, int addMoney)
    {
        missionComplete.SetActive(true);
        missionIsOver = true;
        gameManager.Score += addScore;
        gameManager.Money += addMoney;
        respawn.gameObject.transform.position = this.player.transform.position;
        respawn.SaveData();
    }

    private void MissionFailed()
    {
        if (timerUI.activeInHierarchy)
        {
            if (Timer.timeIsOut)
            {
                missionFailed.SetActive(true);
                missionIsOver = true;
            }
        }
    }

    private void MissionOver()
    {
        if (missionIsOver)
        {
            Invoke("SetMissionFalse", 3f);
            missionIndex++;
            Player.questIsActive = false;
            timerUI.SetActive(false);
            Timer.timeIsOut = false;
        }
    }

    private void QuestTimer(float maximumTime)
    {
        if (Input.GetKeyDown(KeyCode.Q) && Player.questIsActive)
        {
            questUI.SetActive(false);
            timerUI.SetActive(true);
            money.SetActive(true);
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
                    distances[i] = Vector2.Distance(player.transform.position, moneys[i].transform.position);
            
                }
                int index = FindObject.FindIndexOfClosestObject(distances);
                if (distances[index] < 3)
                {
                    GameObject money = moneys[index].gameObject;
                    money.SetActive(false);
                    gameManager.Money += 100;
                }
            }
        }
    }

    void SetMissionFalse()
    {
        missionComplete.SetActive(false);
        missionFailed.SetActive(false);
    }
    
}
