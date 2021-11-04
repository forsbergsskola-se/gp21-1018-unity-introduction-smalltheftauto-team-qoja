using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] private float runSpeed = 20.0f;
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] private Slider staminaBar;
    [SerializeField] private float staminaDrain = 0.4f;
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
        staminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
    }

    private void Start()
    {
        _currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        _canRun = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Run-Button") != 0 && _canRun && Input.GetAxis("Vertical") != 0)
        {
            _speed = runSpeed;
            UseStamina(staminaDrain);
        }
        else _speed = walkSpeed;
        
        transform.Translate(0f, _speed * Time.deltaTime * Input.GetAxis("Vertical"), 0f);
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    private void UseStamina(float amountOfStaminaDrained)
    {
        if (_currentStamina - amountOfStaminaDrained >= 0)
        {
            _currentStamina -= amountOfStaminaDrained;
            staminaBar.value = _currentStamina;

            if (_regen != null)
            {
                StopCoroutine(_regen);
            }

            _regen = StartCoroutine(RegenStamina());
        }
        else
        {
            _canRun = false;
        }
    }
    
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(staminaReloadTime);
        while (_currentStamina < maxStamina)
        {
            _currentStamina += maxStamina / staminaReloadRate;
            _canRun = true;
            staminaBar.value = _currentStamina;
            yield return _regenTick;
        }

        _regen = null;
    }
}
