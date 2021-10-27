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

    private int Score
    {
        get;
        set;
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
        
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            inFire = true;
            Debug.Log("I am in fire");
            StartCoroutine(ImInFire());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            inFire = false;
            StopCoroutine(ImInFire());
            Debug.Log("I left fire");
        }
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

    private IEnumerator ImInFire() //Takes x amount of damage every y seconds
    {
        //Makes bool !inFire after 10 seconds
        while (inFire) { //&& firetimer is not out
            TakeDamage(FireDamage);
            yield return new WaitForSeconds(3);
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
}
