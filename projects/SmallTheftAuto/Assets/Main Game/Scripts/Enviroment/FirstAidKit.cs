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
            // TODO: Oh no, this method is called for all health kits.
            // And every health kit implements this logic for every other health kit
            // I understand, why you implemented it this way, because you want to make sure that the closest HealthKit
            // is always collected, but I think that it would be better, if all interactables had an Interactable component.
            // And there was one script that checks for all interactables and interacts with the closest one.
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