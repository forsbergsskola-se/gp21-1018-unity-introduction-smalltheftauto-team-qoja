using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IHaveHealth
{

    [SerializeField] public int maxHealth = 100;
    private int health;
    private static int money;
    private const int FireDamage = 5;
    private int score;
    private int nextHealth = 100;
    private bool inFire = false;
    private GameObject quest;
    public GameObject questUI;
    public static bool questIsActive;
    private GameObject firstAidKit;
    public GameManager gameManager;

    private void Awake() {
        health = maxHealth;
    }

   /* public Player(int MaxHealth) //Player's constructor
    {
        health = MaxHealth;
    }*/

    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, maxHealth);
    }
    public int Money
    {
        get => money;

        set => money = value;
    }
    public int Score
    {
        get => score;

        set => score = value;
    }
    
    public bool IsAlive
    {
        get => health > 0;
        set => throw new NotImplementedException();
    }

    public bool IsDead
    {
        get => !IsAlive;
        set => throw new NotImplementedException();
    }

    // public static int Money
    // {
    //     get => money;
    //
    //     set => money = value;
    // }

    // public int Score
    // {
    //     get => score;
    //     set => score = value;
    // }

    public GameObject Quest {
        get => quest;
        set => quest = value;
    }

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        
        
        //Debug.Log("My health is " + health);
    }

    private void Update()
    {
        QuestFinder();
        HealthFinder();
    }

    private void OnDeath()
    {
        gameManager.RestartGame();

        
        //Do stuff first
        Health = nextHealth;
        Money = Money / 2;
        transform.position = new Vector3(-13f, -20f, 1.63f);

        
    }
    
    void QuestFinder()
    {
        if (Input.GetKeyDown(KeyCode.E) && !questIsActive)
        {
            Quest[] quests = FindObjectsOfType<Quest>();
            float[] distances = new float[quests.Length];
            for (int i = 0; i < quests.Length; i++)
            {
                distances[i] = Vector3.Distance(this.transform.position, quests[i].transform.position);
            }
            int index = FindObject.FindIndexOfClosestObject(distances);
            if (distances[index] < 4.3)
            {
                quest = quests[index].gameObject;
                questUI.SetActive(true);
                questIsActive = true;
            }
        }
    }
    
    //Needs to be redone and edited for better readability
    void HealthFinder()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FirstAidKit[] firstAidKits = FindObjectsOfType<FirstAidKit>();
            if (firstAidKits.Length != 0)
            {
                float[] distances = new float[firstAidKits.Length];
                for (int i = 0; i < firstAidKits.Length; i++)
                {
                    distances[i] = Vector3.Distance(this.transform.position, firstAidKits[i].transform.position);
                }
                int index = FindObject.FindIndexOfClosestObject(distances);
                if (distances[index] < 4.3)
                {
                    firstAidKit = firstAidKits[index].gameObject;
                    firstAidKit.SetActive(false);
                    Health += 10;
                }
            }
        }
    }
}
