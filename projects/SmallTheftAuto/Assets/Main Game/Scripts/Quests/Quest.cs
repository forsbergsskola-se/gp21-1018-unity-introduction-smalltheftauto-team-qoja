using UnityEngine;

public class Quest : MonoBehaviour
{
    public static string[] quests = {"Collect 200 dollars", "Park a car in parking spot No.2 and get off the car", "Good job! No more quest!"};
    public static int missionIndex;
    public GameObject questUI;
    public GameObject timerUI;
    public GameObject player;
    public GameObject missionComplete;
    public GameObject missionFailed;
    public GameManager gameManager;
    public GameObject money;
    public GameObject parkingSpot;
    public Respawn respawn;
    
    private int _originalMoney; // Used to save the player's money when starting the first quest
    private bool _missionIsOver;
    private bool _moneyReset; // Used to reset the money when player dies during the quest
    private int _maximumTime; // Maximum time to finish the quest.
    private bool _completionCriteria; // The criteria to finish the corresponding quest
    private ParkingSpot _codeOfParkingSpot;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        respawn = FindObjectOfType<Respawn>();
        _codeOfParkingSpot = parkingSpot.GetComponent<ParkingSpot>();
    }

    void Update()
    {
        if (missionIndex == 0)
        {
            _maximumTime = 100;
            _completionCriteria = gameManager.Money - _originalMoney >= 200;
            if (timerUI.activeInHierarchy)
            {
                money.SetActive(true);
                MoneyFinder();
            }
        }
        if (missionIndex == 1)
        {
            _maximumTime = 200;
            _completionCriteria = parkingSpot.GetComponent<ParkingSpot>().isParked && player.activeInHierarchy;
            if (timerUI.activeInHierarchy)
            {
                _codeOfParkingSpot.enabled = true;
                parkingSpot.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if (!Player.questIsActive) _originalMoney = gameManager.Money;
        _missionIsOver = false;
        QuestTimer(_maximumTime);
        if ( _completionCriteria && missionIndex!=quests.Length-1 && timerUI.activeInHierarchy)
        {
            MissionComplete(20,100);
            missionIndex++;
        }
        IfMissionFailed();
        if (_missionIsOver)
        {
            money.SetActive(false);
            parkingSpot.transform.GetChild(0).gameObject.SetActive(false);
            _codeOfParkingSpot.enabled = false;
        }
        MissionOver();
        
        // When there is no more quest
        if (missionIndex > quests.Length-2)
        {
            _missionIsOver = false;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _missionIsOver = true;
                questUI.SetActive(false);
                MissionOver();
            }
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

    private void IfMissionFailed()
    {
        if (timerUI.activeInHierarchy)
        {
            if (Timer.timeIsOut || player.GetComponent<Player>().IsDead)
            {
                missionFailed.SetActive(true);
                _missionIsOver = true;
                _moneyReset = false;
            }
        }
    }

    // Deactivate the animations when mission is over
    private void MissionOver()
    {
        if (_missionIsOver)
        { 
            Invoke("SetMissionFalse", 3f);
            Player.questIsActive = false;
            timerUI.SetActive(false);
            Timer.timeIsOut = false;
        }
    }

    // Activate the timer for the quest
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
    
    // Find the closest money and collect it if the distance is smaller than 3
    private void MoneyFinder()
    {
        if (!_moneyReset)
        {
            for (int i = 0; i < money.transform.childCount; i++)
            {
                money.transform.GetChild(i).gameObject.SetActive(true);
            }
            _moneyReset = true;
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

   private void SetMissionFalse()
    {
        missionComplete.SetActive(false);
        missionFailed.SetActive(false);
    }
    
}
