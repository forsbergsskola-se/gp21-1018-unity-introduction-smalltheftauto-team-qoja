using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICEO : MonoBehaviour
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
            Invoke("DisableWasted", 3);
        }

    }
    void DisableWasted()
    {
        wasted.SetActive(false);
    }
}
