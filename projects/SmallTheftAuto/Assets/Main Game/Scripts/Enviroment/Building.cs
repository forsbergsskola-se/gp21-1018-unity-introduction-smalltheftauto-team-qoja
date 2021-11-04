using UnityEngine;

public class Building : MonoBehaviour, IHurtOnCrash, IHaveHealth
{
    public int maxHealth = 400;
    private int _health;
    public int DamageOnCrash => 10;

    private void Awake()
    {
        _health = maxHealth;
    }
    
    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, maxHealth);
    }
}