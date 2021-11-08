using UnityEngine;

public class Building : MonoBehaviour, IHurtOnCrash, IHaveHealth
{
    // TODO: I am seeing quite a lot of repeated use of health and similar base entity stuffs.
    // I would recommend looking into making a base class Unit/Entity/YourChoice and have that create health, takeDamage or similar.
    // Then when a object needs to be able to take damage and have health all you need is to make the object class inherit Unit, like in the RPG game. :)
    
    
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