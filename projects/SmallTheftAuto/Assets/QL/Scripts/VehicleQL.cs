using UnityEngine;

public class VehicleQL : MonoBehaviour
{
    //public GameObject player;
    //public CarMovementQL carMovement;

    void Start()
    {
        //carMovement.enabled = false;
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
        GameObject driver = FindObjectOfType<GameObject>();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (driver != null)
            {
                LeaveCar(driver);
            }
        }
    }

    //private bool PlayerIsInCar()
    //{
        //return !player.activeInHierarchy;
        //return !GetComponent<GameObject>().activeInHierarchy;
    //}

    //public void EnterCar()
    public void EnterCar(GameObject driver)
    {
        driver.SetActive(false);
        //carMovement.enabled = true;
        //GetComponent<GameObject>().SetActive(false);
        GetComponent<CarMovementQL>().enabled = true;
    }

    public void LeaveCar(GameObject driver)
    {
        driver.transform.position = transform.position;
        driver.SetActive(true);
        //carMovement.enabled = false;
        //GetComponent<GameObject>().transform.position = transform.position;
        //GetComponent<GameObject>().SetActive(true);
        GetComponent<CarMovementQL>().enabled = false;
    }
}
