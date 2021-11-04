using UnityEngine;

public class StreetItem : MonoBehaviour, IHurtOnCrash, IHaveHealth
{
    [SerializeField] private int maxHealth = 10;
    private int health;
    public int DamageOnCrash => 5;
    
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, maxHealth);
    }

    private void Awake()
    {
        health = maxHealth;
    }
}
