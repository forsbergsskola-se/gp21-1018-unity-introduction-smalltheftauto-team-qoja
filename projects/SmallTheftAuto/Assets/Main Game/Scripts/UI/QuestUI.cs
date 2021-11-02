using System;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    private TextMeshProUGUI quest;
    private String questText;
    public GameObject questKeyInfo;
    public GameObject questKeyInfo1;
    void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.enableAutoSizing = true;
    }

    void Update()
    {
        if(Player.questIsActive && Quest.missionIndex==0)
        {
            QuestText(0);
        }
        if(Player.questIsActive && Quest.missionIndex==1)
        {
            QuestText(1);
        }
        if(Quest.missionIndex==2)
        {
            questKeyInfo.SetActive(false);
            questText = Quest.quests[2];
            quest.text = questText;
            questKeyInfo1.SetActive(true);
        }
    }

    void QuestText(int i)
    {
        questText = Quest.quests[i];
        quest.text = questText;
        questKeyInfo.SetActive(true);
        questKeyInfo1.SetActive(false);
    }
}
