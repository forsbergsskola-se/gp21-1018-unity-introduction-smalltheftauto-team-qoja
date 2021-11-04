using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] private float runSpeed = 20.0f;
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] private Slider staminaBar;
    [SerializeField] private float staminaLosingRate = 0.4f;
    [SerializeField] private float staminaReloadTime = 2f;
    [SerializeField] private float staminaReloadRate = 30f;
    private float _speed;
    private float maxStamina = 100;
    private float _currentStamina;
    private Coroutine _regen;
    private bool _canRun;
    private readonly WaitForSeconds _regenTick = new WaitForSeconds(0.1f);

    private void Awake()
    {
        // The slider for the stamina bar
        staminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
    }

    private void Start()
    {
        _currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        _canRun = true;
    }


    void FixedUpdate()
    {

        if (Input.GetAxis("Run-Button") != 0 && _canRun && Input.GetAxis("Vertical") != 0)
        {

            _speed = runSpeed;
            UseStamina(staminaLosingRate);
        }
        else _speed = walkSpeed;
        
        
        transform.Translate(0f, _speed * Time.deltaTime * Input.GetAxis("Vertical"), 0f);
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        
    }

    public void UseStamina(float amount)
    {
        if (_currentStamina - amount >= 0 )
        {
            _currentStamina -= amount;
            staminaBar.value = _currentStamina;

            if (_regen != null)
            {
                StopCoroutine(_regen);
            }

            _regen = StartCoroutine(RegenStamina());
        }
        else
        {
            // The player cannot run while the stamina is zero or under.
            _canRun = false;
        }
    }

    // Method for regenerating the lost stamina
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(staminaReloadTime);
        while (_currentStamina < maxStamina)
        {
            _currentStamina += maxStamina / staminaReloadRate;
            // We set the can run to true in order to make it possible to run while regenerating the bar(and after)
            _canRun = true;
            staminaBar.value = _currentStamina;
            yield return _regenTick;
        }

        _regen = null;
    }
}
