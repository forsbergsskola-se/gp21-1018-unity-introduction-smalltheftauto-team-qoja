using System;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour, IHurtOnCrash, IHaveHealth {
    public int DamageOnCrash => 5;
    public Vector3 playerOffset = new Vector3(3, 0, 0);
    public int maxHealth = 200;
    private int _health;
    private GameObject _driver;
    private Explosion _explosion;
    private VehicleMovement _vehicleMovement;
    private Radio _radio;

    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, maxHealth);
    }
    
    private void Awake() {
        _health = maxHealth;
        _vehicleMovement = GetComponent<VehicleMovement>();
        _radio = gameObject.GetComponentInChildren<Radio>();
        _explosion = GetComponent<Explosion>();
        
        DisableExplosion(_explosion);
        ToggleVehicleMovement(_vehicleMovement, false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (_driver != null)
            {
                ExitCar(playerOffset);
            }
        }
    }

    public void EnterCar(GameObject player)
    {
        _driver = player;
        _driver.SetActive(false);
        
        ToggleVehicleMovement(_vehicleMovement, true);
        OnOffRadio(_radio, true);
    }

    public void ExitCar(Vector3 vehiclePlayerOffset) {

        _driver.transform.parent = null;
        _driver.transform.position = transform.position + playerOffset;
        _driver.SetActive(true);
        _driver = null;

        ToggleVehicleMovement(_vehicleMovement, false);
        OnOffRadio(_radio, false);
    }


    private void DisableExplosion(Explosion explosion) {
        if (explosion != null) {
            explosion.enabled = false;
        }
    }
    
    private void ToggleVehicleMovement(VehicleMovement vehicleMovement, bool value) {
        if (vehicleMovement != null) {
            vehicleMovement.enabled = value;
        }
    }
    
    private void OnOffRadio(Radio radio, bool value) {
        if (_radio != null) {
            _radio.ToggleRadio(value);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageArea damageArea = other.GetComponent<DamageArea>();
        if (damageArea != null) {
            if (damageArea.InWater(DamageArea.DamageAreaType.Water)) {
                
            }
        }
    }

    private void DisableInWater() {
        
    }
} 

