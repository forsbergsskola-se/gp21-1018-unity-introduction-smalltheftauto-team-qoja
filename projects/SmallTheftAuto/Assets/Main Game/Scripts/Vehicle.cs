using System;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour, IHurtOnCrash, IHaveHealth {
    [SerializeField] private int maxHealth = 200;
    private int health;
    private GameObject driver;
    public Vector3 playerOffset = new Vector3(3, 0, 0);
    private int buildingDamage = 10;
    private Explosion explosion;
    private VehicleMovement _vehicleMovement;
    private Radio radio;
    private Driver _driver;
    public int DamageOnCrash => 5;
    
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, maxHealth);
    }
    
    private void Awake() {
        health = maxHealth;
        _vehicleMovement = GetComponent<VehicleMovement>();
        
        if (_vehicleMovement != null) {
            _vehicleMovement.enabled = false;
        }
        
        GetComponent<VehicleMovement>().enabled = false;
        //GetComponentInChildren<Radio>().enabled = false;
        
        radio = gameObject.GetComponentInChildren<Radio>();
        explosion = GetComponent<Explosion>();
        explosion.enabled = false;
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
        driver.SetActive(false);
        if (_vehicleMovement != null)
        {
            _vehicleMovement.enabled = true;
        }
        
        if (radio != null)
        {
            radio.ToggleRadio(true);
        }
    }

    public void ExitCar(Vector3 playerOffset) {
        driver.transform.parent = null;
        driver.transform.position = transform.position + playerOffset;
        driver.SetActive(true);
       // Rigidbody2D driverBody = driver.GetComponent<Rigidbody2D>();
        //driverBody.velocity = Vector2.zero;
        //driverBody.angularVelocity = 0.0f;
        driver = null;
        if (_vehicleMovement != null)
        {
            _vehicleMovement.enabled = false;
        }
        
        if (radio != null)
        {
            radio.ToggleRadio(false);
        }
       
       // GetComponentInChildren<Radio>().enabled = false;
    }
} 

