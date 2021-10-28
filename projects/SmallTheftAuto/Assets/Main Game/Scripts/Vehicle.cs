using System;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour, IHurtOnCrash, IHaveHealth {
    [SerializeField] private int maxHealth = 200;
    private int health;
    private GameObject driver;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    private int buildingDamage = 10;
    private Explosion explosion;
    public int DamageOnCrash => 5;
    
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, maxHealth);
    }
    
    private void Awake()
    {
        GetComponent<VehicleMovement>().enabled = false;
        explosion = GetComponent<Explosion>();
        explosion.enabled = false;
        health = maxHealth;
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (driver != null)
            {
                ExitCar(playerOffset);
            }
        }
    }

    public void EnterCar(GameObject player)
    {
        driver = player;
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
    }

    public void ExitCar(Vector3 playerOffset)
    {
        Debug.Log("I'm in exit method");
        driver.transform.parent = null;
        driver.transform.position = transform.position + playerOffset;
        driver.SetActive(true);
        Debug.Log("I exited");
        driver = null;
        GetComponent<VehicleMovement>().enabled = false;
    }
} 

