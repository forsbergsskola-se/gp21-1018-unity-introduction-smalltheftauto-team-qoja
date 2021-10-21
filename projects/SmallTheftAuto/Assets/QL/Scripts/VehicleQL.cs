using UnityEngine;

public class VehicleQL : MonoBehaviour
{
    private GameObject driver;
    public GameObject player;
    void Start()
    {
        GetComponent<CarMovementQL>().enabled = false;
    }
    
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        // if(Input.GetButtonDown("Interact-Vehicle"))
        // {
        //     if (!PlayerIsInCar())
        //     {
        //         float distance = Vector3.Distance(player.transform.position, transform.position);
        //         //float distance = Vector3.Distance(GetComponent<GameObject>().transform.position, transform.position);
        //         if(distance < 3)
        //             EnterCar();
        //     }
        //     else
        //     {
        //         LeaveCar();
        //     }
        // }
        
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (driver != null)
            {
                LeaveCar();
            }
        }
    }

    //private bool PlayerIsInCar()
    //{
        //return !player.activeInHierarchy;
        //return !GetComponent<GameObject>().activeInHierarchy;
    //}

    public void EnterCar(GameObject player)
    {
        driver = player;
        player.SetActive(false);
        GetComponent<CarMovementQL>().enabled = true;
    }

    private void LeaveCar()
    {
        driver.transform.position = this.transform.position;
        player.SetActive(true);
        player = driver;
        driver = null;
        GetComponent<CarMovementQL>().enabled = false;
    }
}
