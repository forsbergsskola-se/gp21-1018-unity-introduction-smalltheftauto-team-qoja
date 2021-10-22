using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private GameObject driver;
    //public GameObject player;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    void Start() {
        GetComponent<VehicleMovement>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (driver != null)
            {
                ExitCar(playerOffset);
            }
        }
    }

    public void EnterCar(GameObject player)
    {
        driver = player;
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
        gameObject.tag = "Player";
    }

    public void ExitCar(Vector3 playerOffset) {
        driver.transform.position = transform.position + playerOffset;
        Debug.Log("I'm suppose to exit");
        driver.SetActive(true);
        Debug.Log("I'm exited");
        //player = driver;
        driver = null;
        GetComponent<VehicleMovement>().enabled = false;
        gameObject.tag = "Vehicle";
    }
} 

