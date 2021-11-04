using Unity.VisualScripting;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject questUI;
    public GameObject timerUI;
    public GameObject player;
    public GameObject missionComplete;
    public GameObject missionFailed;
    public GameManager gameManager;
    public Respawn respawn;
    public static string[] quests = {"Collect 200 dollars", "Park a car in parking spot No.2 and get off the car", "Good job! No more quest!"};
    public GameObject money;
    public GameObject parkingSpot;
    public static int missionIndex;
    
    private int originalMoney;
    private bool missionIsOver;
    private bool moneyReset;

    private int maximumTime;
    private bool completionCritera;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        respawn = FindObjectOfType<Respawn>();
    }

    void Update()
    {
        // if(!Player.questIsActive) originalMoney = gameManager.Money;
        // if (missionIndex == 0)
        // {
        //     missionIsOver = false;
        //     QuestTimer(100);
        //     
        //     if (timerUI.activeInHierarchy)
        //     {
        //         money.SetActive(true);
        //         MoneyFinder();
        //     }
        //     if (gameManager.Money - originalMoney >= 200 && !missionIsOver && timerUI.activeInHierarchy)
        //     {
        //         MissionComplete(20, 100);
        //         missionIndex++;
        //     }
        //     IfMissionFailed();
        //     if(missionIsOver) money.SetActive(false);
        //     MissionOver();
        // }
        // if (missionIndex == 1)
        // {
        //     missionIsOver = false;
        //     QuestTimer(200);
        //     if (timerUI.activeInHierarchy)
        //     {
        //         parkingSpot.GetComponent<ParkingSpot>().enabled = true;
        //         parkingSpot.transform.GetChild(0).gameObject.SetActive(true);
        //     }
        //     if(parkingSpot.GetComponent<ParkingSpot>().parked && !missionIsOver && timerUI.activeInHierarchy)
        //     {
        //         if (player.activeInHierarchy)
        //         {
        //             MissionComplete(20,100);
        //             missionIndex++;
        //         }
        //     }
        //     if(missionIsOver) parkingSpot.transform.GetChild(0).gameObject.SetActive(false);
        //     IfMissionFailed();
        //     MissionOver();
        // }
        
        if (missionIndex == 0)
        {
            maximumTime = 100;
            completionCritera = gameManager.Money - originalMoney >= 200;
            if (timerUI.activeInHierarchy)
            {
                money.SetActive(true);
                MoneyFinder();
            }
        }
        if (missionIndex == 1)
        {
            maximumTime = 200;
            completionCritera = parkingSpot.GetComponent<ParkingSpot>().parked && player.activeInHierarchy;
            if (timerUI.activeInHierarchy)
            {
                parkingSpot.GetComponent<ParkingSpot>().enabled = true;
                parkingSpot.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if (!Player.questIsActive) originalMoney = gameManager.Money;
        missionIsOver = false;
        QuestTimer(maximumTime);
        if (completionCritera && missionIndex!=quests.Length-1 && timerUI.activeInHierarchy)
        {
            MissionComplete(20,100);
            missionIndex++;
        }
        IfMissionFailed();
        if (missionIsOver)
        {
            money.SetActive(false);
            parkingSpot.transform.GetChild(0).gameObject.SetActive(false);
        }
        MissionOver();
        if (missionIndex > quests.Length-2)
        {
            missionIsOver = false;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                missionIsOver = true;
                questUI.SetActive(false);
                MissionOver();
            }
        }
    }

    private void MissionComplete(int addScore, int addMoney)
    {
        missionComplete.SetActive(true);
        missionIsOver = true;
        gameManager.Score += addScore;
        gameManager.Money += addMoney;
        respawn.SaveData();
    }

    private void IfMissionFailed()
    {
        if (timerUI.activeInHierarchy)
        {
            if (Timer.timeIsOut || player.GetComponent<Player>().IsDead)
            {
                missionFailed.SetActive(true);
                missionIsOver = true;
                moneyReset = false;
            }
        }
    }

    private void MissionOver()
    {
        if (missionIsOver)
        { 
            Invoke("SetMissionFalse", 3f);
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
            Timer.maxTime = maximumTime;
            Timer.timePassed = 0;
        }
    }

    void MoneyFinder()
    {
        if (!moneyReset)
        {
            for (int i = 0; i < money.transform.childCount; i++)
            {
                money.transform.GetChild(i).gameObject.SetActive(true);
            }
            moneyReset = true;
        }
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
