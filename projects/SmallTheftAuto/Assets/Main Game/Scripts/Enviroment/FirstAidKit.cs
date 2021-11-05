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
            FirstAidKit[] firstAidKits = FindObjectsOfType<FirstAidKit>();
            
            if (firstAidKits.Length != 0)
            {
                float[] distances = new float[firstAidKits.Length];
                
                for (int i = 0; i < firstAidKits.Length; i++)
                {
                    distances[i] = Vector2.Distance(this.transform.position, firstAidKits[i].transform.position);
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