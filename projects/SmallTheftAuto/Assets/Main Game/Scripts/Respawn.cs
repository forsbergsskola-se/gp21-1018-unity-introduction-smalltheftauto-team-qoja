using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Player player;
    public int health;
    public int score;
    public int money;

    private int Health
    {
        get => health;
        set => health = value;

    }
    private int Money
    {
        get => money;

        set => money = value;
    }

    private int Score
    {
        get => score;

        set => score = value;
    }

    public void RespawnPoint()
    {
        player.transform.position = this.gameObject.transform.position;
    }

    // public void SetRespawnPoint()
    // {
    //     respawn.gameObject.transform.position = this.transform.position;
    // }

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void SaveData()
    {
        Health = player.Health;
        Score = player.Score;
        Money = player.Money;
    }

    public void LoadData()
    {
        Health = health;
        Money = money;
        Score = score;
    }
}
