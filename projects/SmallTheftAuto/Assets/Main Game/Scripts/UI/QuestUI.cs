using System;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    private TextMeshProUGUI quest;
    public GameObject player;
    private String questText;
    void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.enableAutoSizing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().Quest != null)
        {
            questText = "Go kill!"; //Problem: need to figure out how to get the content of the quest
            //questText = player.GetComponent<Quest>().questContent;
            quest.text = questText;
        }
    }
}
