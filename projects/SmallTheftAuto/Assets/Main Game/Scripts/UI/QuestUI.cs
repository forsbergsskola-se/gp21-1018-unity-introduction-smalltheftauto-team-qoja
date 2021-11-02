using System;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    private TextMeshProUGUI quest;
    private String questText;
    public GameObject QuestKeyInfo;
    public GameObject QuestKeyInfo1;
    void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.enableAutoSizing = true;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.P)) Debug.Log(Player.questIsActive);
        if(Player.questIsActive && Quest.missionIndex==0)
        {
            questText = Quest.quests[0];
            quest.text = questText;
            QuestKeyInfo.SetActive(true);
        }
        if(Player.questIsActive && Quest.missionIndex==1)
        {
            questText = Quest.quests[1];
            quest.text = questText;
            QuestKeyInfo.SetActive(true);
        }
        if(Quest.missionIndex==2)
        {
            QuestKeyInfo.SetActive(false);
            questText = Quest.quests[2];
            quest.text = questText;
            QuestKeyInfo1.SetActive(true);
        }
    }
}
