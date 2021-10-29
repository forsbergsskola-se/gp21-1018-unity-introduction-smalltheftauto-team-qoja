using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Player player;
    public void RespawnPoint()
    {
        player.transform.position = this.gameObject.transform.position;
    }

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }
}
