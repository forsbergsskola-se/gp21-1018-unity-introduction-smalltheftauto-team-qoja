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
            if (!PlayerIsInCar())
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if(distance < 3)
                    EnterCar();
            }
            else
            {
                LeaveCar();
            }
        }
    }

    private bool PlayerIsInCar()
    {
        return !player.activeInHierarchy;
    }

    public void EnterCar()
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    public void LeaveCar()
    {
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
}
