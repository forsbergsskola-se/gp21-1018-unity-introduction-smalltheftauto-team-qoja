using UnityEngine;

public class VehicleQL : MonoBehaviour
{
    public GameObject player;
    public CarMovementQL carMovement;
    
    void Start()
    {
        carMovement.enabled = false;
    }
    
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        if(Input.GetButtonDown("Interact-Vehicle"))
        {
            if (player.activeInHierarchy)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                Debug.Log(distance);
                if(distance < 3)
                    EnterCar();
            }
            else
            {
                LeaveCar();
            }
        }
    }

    void EnterCar()
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    void LeaveCar()
    {
        player.transform.position = this.transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
}
