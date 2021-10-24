using UnityEngine;

public class VehicleQL : MonoBehaviour
{
    private GameObject driver;
    private int health;
    private int burningThreshold;
    void Start()
    {
        GetComponent<CarMovementQL>().enabled = false;
        health = 2;
        burningThreshold = 1;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (driver != null)
            {
                LeaveCar();
            }
        }
        
    }

    //public void EnterCar(GameObject player)
    public void EnterCar()
    {
        //GameObject player = FindObjectOfType<PlayerMovementQL>().gameObject;
        //driver = player;
        //player.SetActive(false);
        driver = FindObjectOfType<PlayerMovementQL>().gameObject;
        driver.SetActive(false);
        GetComponent<CarMovementQL>().enabled = true;
    }
    private void LeaveCar()
    {
        driver.transform.position = this.transform.position;
        driver.SetActive(true);
        driver = null;
        GetComponent<CarMovementQL>().enabled = false;
    }

   private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            health--;
            Debug.Log("Collided! Health of the car is: "+health);
            if (health == burningThreshold)
            {
                CarBurning();
            }

            if (health == 0)
            {
                CarExplode();
            }
        }
    }

   private void CarBurning()
   {
       Debug.Log("The car starts burning!");
   }

   private void CarExplode()
   {
       Debug.Log("The car explodes!");
       if (driver != null)
       {
           Debug.Log("The player dies!");
       }
   }
}
