using UnityEngine;

public class VehicleOK : MonoBehaviour
{
    private GameObject driver;
    //public GameObject player;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    //private GameObject NiceCarOK;
    void Start() {
        GetComponent<VehicleMovementOK>().enabled = false;
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
        GetComponent<VehicleMovementOK>().enabled = true;
        gameObject.tag = "Player";
       // GameObject NiceCarPrefab = GameObject.Instantiate(NiceCarOK, this.transform.position, 0);
        
    }

    public void ExitCar(Vector3 playerOffset) {
        driver.transform.position = transform.position + playerOffset;
        Debug.Log("I'm suppose to exit");
        driver.SetActive(true);
        Debug.Log("I'm exited");
        //player = driver;
        driver = null;
        GetComponent<VehicleMovementOK>().enabled = false;
        gameObject.tag = "Vehicle";
    }
}