using UnityEngine;

public class OnDeathUI : MonoBehaviour
{
    public Player player;
    public GameObject wasted;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        if (player.IsDead)
        {
            wasted.SetActive(true);
            Invoke(nameof(DisableWasted), 3);
        }

    }
    
    void DisableWasted()
    {
        wasted.SetActive(false);
    }
}
