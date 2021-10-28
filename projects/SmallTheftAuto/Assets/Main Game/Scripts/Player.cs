using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private int health = 100;
    private static int money = 0;
    private const int FireDamage = 5;
    private int score;

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

    private bool inFire = false;
    private GameObject quest;
    public GameObject questUI;
    public static bool questIsActive;
    public GameObject timerUI;
    private GameObject firstAidKit;

    public Player(int MaxHealth) //Player's constructor
    {
        this.health = MaxHealth;

    }

    public int Health
    {
        get => health;
        set => health = value;
    }

    public static int Money
    {
        get => money;

        set => money = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }

    public GameObject Quest
    {
        get => quest;
        set => quest = value;
    }

    private void Start() {
        Debug.Log("My health is " + health);
    }

    private void Update()
    {
        
        if (inFire)
        {
            
        }
        QuestFinder();
        HealthFinder();
        
    }
    
    //Want to move this to destructible but it fucks up UI
    private void TakeDamage(int damage)
    {
        Debug.Log("Damage value is " + damage);
        health -= damage;
        Debug.Log("My health is " + health);
        if(IsDead)
        {
            OnDeath();
        }
    }
    
    private void OnDeath()
    {
        
        //Do stuff first
        
        //RestartScene()  - Call this method from GameManager
    }

    public void EquipWeapon()
    {
        
    }

    void QuestFinder()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.quest==null)
        {
            Quest[] quests = FindObjectsOfType<Quest>();
            float[] distances = new float[quests.Length];
            for (int i = 0; i < quests.Length; i++)
            {
                distances[i] = Vector3.Distance(this.transform.position, quests[i].transform.position);
                
            }
            int index = this.GetComponent<Driver>().FindClosestCar(distances);
            if (distances[index] < 4.3)
            {
                //Debug.Log("Go kill people!");
                quest = quests[index].gameObject;
                //quest.SetActive(false);
                questUI.SetActive(true);
                questIsActive = true;
            }
            
        }
        
    }
    
    void HealthFinder()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FirstAidKit[] firstAidKits = FindObjectsOfType<FirstAidKit>();
            float[] distances = new float[firstAidKits.Length];
            for (int i = 0; i < firstAidKits.Length; i++)
            {
                distances[i] = Vector3.Distance(this.transform.position, firstAidKits[i].transform.position);
                
            }
            int index = this.GetComponent<Driver>().FindClosestCar(distances);
            if (distances[index] < 4.3)
            {
                
                firstAidKit = firstAidKits[index].gameObject;
                //quest.SetActive(false);
                firstAidKit.SetActive(false);
                Health += 10;

            }
            
        }
        
    }
}
