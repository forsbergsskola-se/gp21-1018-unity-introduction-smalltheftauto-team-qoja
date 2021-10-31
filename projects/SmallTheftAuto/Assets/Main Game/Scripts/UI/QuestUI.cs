using System;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    private TextMeshProUGUI quest;
    private String questText;
    
    void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.enableAutoSizing = true;
    }

    void Update()
    {
        if(Player.questIsActive && Quest.missionIndex==0)
        {
            questText = Quest.quests[0];
            quest.text = questText;
        }
        if(Player.questIsActive && Quest.missionIndex==1)
        {
            questText = Quest.quests[1];
            quest.text = questText;
        }
    }
}
