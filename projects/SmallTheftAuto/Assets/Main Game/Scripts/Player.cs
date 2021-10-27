using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private int health = 100;
    private int money = 0;
    private const int FireDamage = 5;

    public bool IsAlive => health > 0;
    public bool IsDead => !IsAlive;
    private bool inFire = false;
    private GameObject quest;
    public GameObject questUI;
    private bool questIsActive;

    public Player(int MaxHealth) //Player's constructor
    {
        this.health = MaxHealth;

    }

    public int Health
    {
        get => health;
    }
    
    public int Money
    {
        get => money;
    }
    private int Score
    {
        get;
        set;
    }

    public GameObject Quest
    {
        get => quest;
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
        if (Input.GetKeyDown(KeyCode.Q) && questIsActive)
        {
            questUI.SetActive(false);
        }
    }
}
