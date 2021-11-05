using System.Collections;
using UnityEngine;

public class Vehicle : MonoBehaviour, IHurtOnCrash, IHaveHealth {
    public Vector3 playerOffset = new Vector3(3, 0, 0);
    public int DamageOnCrash => 5;
    public int maxHealth = 200;
    private GameObject _driver;
    private Explosion _explosion;
    private VehicleMovement _vehicleMovement;
    private Radio _radio;
    private Destructible _destructible;
    private DamageArea _damageArea;
    private int _health;
    private bool _inWater;

    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, maxHealth);
    }
    
    private void Awake()
    {
        _health = maxHealth;
        _vehicleMovement = GetComponent<VehicleMovement>();
        _radio = gameObject.GetComponentInChildren<Radio>();
        _explosion = GetComponent<Explosion>();
        _destructible = GetComponent<Destructible>();
        
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _damageArea = other.GetComponent<DamageArea>();

        if (_damageArea != null)
        {
            if (_damageArea.InWater())
            {
                _inWater = true;
                
                if (_vehicleMovement != null)
                {
                    StartCoroutine(WaitForSecondsDisableCar(5));
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_inWater)
        {
            _inWater = false;
        }
        
    }

    public void EnterCar(GameObject player)
    {
        _driver = player;
        _driver.SetActive(false);
        
        ToggleVehicleMovement(_vehicleMovement, true);
        OnOffRadio(true);
    }

    public void ExitCar(Vector3 vehiclePlayerOffset)
    {
        _driver.transform.parent = null;
        _driver.transform.position = transform.position + vehiclePlayerOffset;
        _driver.SetActive(true);
        _driver = null;

        ToggleVehicleMovement(_vehicleMovement, false);
        OnOffRadio(false);
    }


    private void DisableExplosion(Explosion explosion)
    {
        if (explosion != null)
        {
            explosion.enabled = false;
        }
    }
    
    private void ToggleVehicleMovement(VehicleMovement vehicleMovement, bool value)
    {
        if (vehicleMovement != null)
        {
            vehicleMovement.enabled = value;
        }
    }
    
    private void OnOffRadio(bool value)
    {
        if (_radio != null)
        {
            _radio.ToggleRadio(value);
        }
    }
    
    private IEnumerator WaitForSecondsDisableCar(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (_inWater)
        {
            DisableCar();
        }
    }

    private void DisableCar()
    {
        _vehicleMovement.MAXSpeed = 0;
        _destructible.enabled = false;
    }
} 