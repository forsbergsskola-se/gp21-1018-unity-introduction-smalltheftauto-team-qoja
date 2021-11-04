using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    private float speed;
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] private float runSpeed = 20.0f;
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] 
    private Slider staminaBar;
    [SerializeField] private float staminaLosingRate = 0.4f;
    private float maxStamina = 100;
    private float currentStamina;
    private Coroutine regen;
    private bool canRun;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    
    
    private bool _isRunning = false;

    private void Awake()
    {
        staminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
    }

    private void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        canRun = true;
    }


    void FixedUpdate()
    {

        if (Input.GetAxis("Run-Button") != 0 && canRun && Input.GetAxis("Vertical") != 0)
        {

            speed = runSpeed;
            UseStamina(staminaLosingRate);
        }
        else speed = walkSpeed;
        
        
        transform.Translate(0f, speed * Time.deltaTime * Input.GetAxis("Vertical"), 0f);
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        
        
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= 0 )
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Not enough stamina!");
            canRun = false;
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);
        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 30;
            canRun = true;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }

        regen = null;
    }
}
