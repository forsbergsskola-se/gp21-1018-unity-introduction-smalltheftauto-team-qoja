public class StreetItemsDestructible : Destructible
{
    public override void Update()
    {
        if (HealthInterface.Health <= 0 && !HasDied)
        {
            OnDeath();
        }
    }

    protected override void OnDeath()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}