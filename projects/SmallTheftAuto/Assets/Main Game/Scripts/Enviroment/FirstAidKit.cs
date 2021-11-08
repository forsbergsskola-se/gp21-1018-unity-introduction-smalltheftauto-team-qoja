using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public Player player;
    private GameObject _firstAidKit;
    
    
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        HealthFinder();
    }


    private void HealthFinder()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            // Avoid to call FindObjectsOfType and similar stuff more than needed. 
            // In this case I would make the following into a list instead, and put it inside start. Then when a healpack is picked up remove it from the list so it cant be picked up again.
            FirstAidKit[] firstAidKits = FindObjectsOfType<FirstAidKit>();
            
            if (firstAidKits.Length != 0)
            {
                float[] distances = new float[firstAidKits.Length];
                
                for (int i = 0; i < firstAidKits.Length; i++)
                {
                    distances[i] = Vector2.Distance(player.transform.position, firstAidKits[i].transform.position);
                }
                
                int index = FindObject.FindIndexOfClosestObject(distances);
                
                if (distances[index] < 3)
                {
                    _firstAidKit = firstAidKits[index].gameObject;
                    _firstAidKit.SetActive(false);
                    player.Health += 10;
                }
            }
        }
    }
}