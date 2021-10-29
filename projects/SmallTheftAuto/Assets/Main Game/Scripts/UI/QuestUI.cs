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
        if(Player.questIsActive && Quest.missionIndex==0)
        //if (player.GetComponent<Player>().Quest != null)
        {
            questText = "Collect 200 dollars!"; //Problem: need to figure out how to get the content of the quest
            //questText = player.GetComponent<Quest>().questContent;
            quest.text = questText;
        }
        if(Player.questIsActive && Quest.missionIndex==1)
        {
            questText = "Collect 100 dollars!";
            quest.text = questText;
        }
    }
}
