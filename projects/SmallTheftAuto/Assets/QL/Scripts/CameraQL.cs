using UnityEngine;

public class CameraQL : MonoBehaviour
{
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private PlayerMovementQL player;
    private CarMovementQL car;
    private Transform target;
    void Start()
    {
        player = FindObjectOfType<PlayerMovementQL>();
        target = player.transform;
    }

    void Update()
    {
        if (!player.isActiveAndEnabled)
        {
            car = FindObjectOfType<CarMovementQL>();
            target = car.transform;
        }
        else
        {
            player = FindObjectOfType<PlayerMovementQL>();
            target = player.transform;
        }
        Vector3 goalPos = target.position;
        goalPos.z = -10;
        this.transform.position = Vector3.SmoothDamp (transform.position, goalPos, ref velocity, smoothTime);
    }
}
