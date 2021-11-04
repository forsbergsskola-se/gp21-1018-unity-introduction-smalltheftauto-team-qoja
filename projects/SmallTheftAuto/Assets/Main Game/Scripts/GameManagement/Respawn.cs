using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Player player;
    private int health;
    private int score;
    private int money;

    public int Health
    {
        get => health;
        set => health = value;

    }
    public int Money
    {
        get => money;

        set => money = value;
    }

    public int Score
    {
        get => score;

        set => score = value;
    }

    public void RespawnPoint()
    {
        player.transform.position = this.gameObject.transform.position;
    }

    public void SetRespawnPoint()
    {
       gameObject.transform.position = player.transform.position;
    }

    public void Start()
    {
        player = FindObjectOfType<Player>();
        SaveData();
    }

    public void SaveData()
    {
        SetRespawnPoint();
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
