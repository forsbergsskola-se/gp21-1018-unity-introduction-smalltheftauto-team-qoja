using UnityEngine;

public class CameraQL : MonoBehaviour
{
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private PlayerMovementQL player;
    private CarMovementQL[] cars;
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
            cars = FindObjectsOfType<CarMovementQL>();
            float[] distances = new float[cars.Length];
            for (int i = 0; i < cars.Length; i++)
            {
                distances[i] = Vector3.Distance(this.transform.position, cars[i].transform.position);
            }
            int index = Min(distances);
            target = cars[index].transform;
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
    public int Min(float[] array)
    {
        int index=0;
        float tmp = 1000f;
        for(int i=0; i<array.Length; i++)
        {
            if (array[i] < tmp)
            {
                tmp = array[i];
                index = i;
            }
        }
        return index;
    }
}
