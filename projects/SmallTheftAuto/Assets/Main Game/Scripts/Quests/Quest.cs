using UnityEngine;
using UnityEngine.Serialization;

public class Quest : MonoBehaviour
{
    public static string[] Quests = {"Collect 200 dollars", "Kill the bad guy with your weapon", "Park a car in parking spot No.2 and get off the car", "Good job! No more quest!"};
    public static int MissionIndex;
    public GameObject questUI;
    public GameObject timerUI;
    public GameObject player;
    public GameObject missionComplete;
    public GameObject missionFailed;
    public GameManager gameManager;
    [FormerlySerializedAs("money")] public GameObject moneyDiscovered;
    public GameObject parkingSpot;
    public Respawn respawn;
    public GameObject shootingTarget;
    
    private ParkingSpot _codeOfParkingSpot;
    private int _originalMoney;
    private bool _missionIsOver;
    private bool _moneyReset;
    private int _maximumTime;
    private bool _completionCriteria;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        respawn = FindObjectOfType<Respawn>();
        _codeOfParkingSpot = parkingSpot.GetComponent<ParkingSpot>();
    }

    void Update()
    {
        //Mission 1
        if (MissionIndex == 0)
        {
            MissionOne();
        }
        
        //Mission 2
        if (MissionIndex == 1)
        {
            MissionTwo();
        }
        
        //Mission 3
        if (MissionIndex == 2)
        {
            MissionThree();
        }

        if (!Player.QuestIsActive)
        {
            _originalMoney = gameManager.Money;
        }
        
        _missionIsOver = false;
        QuestTimer(_maximumTime);
        
        if ( _completionCriteria && MissionIndex!=Quests.Length - 1 && timerUI.activeInHierarchy)
        {
            MissionComplete(20,100);
            MissionIndex++;
        }

        if (timerUI.activeInHierarchy && (Timer.TimeIsOut || player.GetComponent<Player>().IsDead))
        {
            MissionFailed();
        }

        if (_missionIsOver)
        {
            MissionOver();
        }

        //When there is no more quest
        if (MissionIndex > Quests.Length - 2)
        {
            NoMoreQuests();
        }
    }

    private void MissionOne()
    {
        _maximumTime = 20;
            
        //When the player has collected  200 dollars criteria is met
        _completionCriteria = gameManager.Money - _originalMoney >= 200;
            
        if (timerUI.activeInHierarchy)
        {
            moneyDiscovered.SetActive(true);
            MoneyFinder();
        }
    }
    
    private void MissionTwo()
    {
        _maximumTime = 20;
            
        //When the player has killed the target criteria is met
        _completionCriteria = shootingTarget.activeInHierarchy && shootingTarget.GetComponent<ShootingTarget>().IsDead;
        
        if (timerUI.activeInHierarchy)
        {
            shootingTarget.SetActive(true);
        }
    }
    

    private void MissionThree()
    {
        _maximumTime = 200;
            
        //When the player has parked in the correct spot and leaves car criteria is met
        _completionCriteria = parkingSpot.GetComponent<ParkingSpot>().isParked && player.activeInHierarchy;
            
        if (timerUI.activeInHierarchy)
        {
            _codeOfParkingSpot.enabled = true;
                
            //Turns minimap icon for missions parking spot on
            parkingSpot.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void MissionComplete(int addScore, int addMoney)
    {
        missionComplete.SetActive(true);
        _missionIsOver = true;
        gameManager.Score += addScore;
        gameManager.Money += addMoney;
        respawn.SaveData();
    }

    private void MissionFailed()
    {
        missionFailed.SetActive(true);
        _missionIsOver = true;
        _moneyReset = false;
    }

    // Deactivate the animations when mission is over
    private void MissionOver()
    {
        DeactivateMissionObjects();
        Invoke(nameof(SetMissionFalse), 3f);
        Player.QuestIsActive = false;
        timerUI.SetActive(false);
        Timer.TimeIsOut = false;
    }
    private void DeactivateMissionObjects()
    {
        moneyDiscovered.SetActive(false);
        shootingTarget.SetActive(false);
        parkingSpot.transform.GetChild(0).gameObject.SetActive(false);
        _codeOfParkingSpot.enabled = false;
    }
    private void NoMoreQuests()
    {
        _missionIsOver = false;
                    
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _missionIsOver = true;
            questUI.SetActive(false);
            MissionOver();
        }
    }

    // Activate the timer for the quest
    private void QuestTimer(float maximumTime)
    {
        if (Input.GetKeyDown(KeyCode.Q) && Player.QuestIsActive)
        {
            questUI.SetActive(false);
            timerUI.SetActive(true);
            Timer.MAXTime = maximumTime;
            Timer.TimePassed = 0;
        }
    }
    
    // Find the closest money and collect it if the distance is smaller than 3
    private void MoneyFinder()
    {
        if (!_moneyReset)
        {
            ActivateMoney();
            _moneyReset = true;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && Player.QuestIsActive)
        {
            var allMoney = GameObject.FindGameObjectsWithTag("Money");
            int collectionRange = 3;

            if (allMoney.Length != 0)
            {
                //Stores distance between player and all money
                float[] distances = new float[allMoney.Length];
                
                for (int i = 0; i < allMoney.Length; i++)
                {
                    distances[i] = Vector2.Distance(player.transform.position, allMoney[i].transform.position);
                }
                
                //Finds closest Money and collects it
                int index = FindObject.FindIndexOfClosestObject(distances);
                
                if (distances[index] < collectionRange)
                {
                    GameObject money = allMoney[index].gameObject;
                    money.SetActive(false);
                    gameManager.Money += 100;
                }
            }
        }
    }
    private void ActivateMoney()
    {
        for (int i = 0; i < moneyDiscovered.transform.childCount; i++)
        {
            moneyDiscovered.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

   private void SetMissionFalse()
    {
        missionComplete.SetActive(false);
        missionFailed.SetActive(false);
    }
}
