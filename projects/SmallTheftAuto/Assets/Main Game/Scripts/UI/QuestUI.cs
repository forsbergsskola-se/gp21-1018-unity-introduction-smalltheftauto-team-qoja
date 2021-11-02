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
        if(Input.GetKey(KeyCode.P)) Debug.Log(Player.questIsActive);
        if(Player.questIsActive && Quest.missionIndex==0)
        {
            questText = Quest.quests[0];
            quest.text = questText;
            questKeyInfo.SetActive(true);
        }
        if(Player.questIsActive && Quest.missionIndex==1)
        {
            questText = Quest.quests[1];
            quest.text = questText;
            questKeyInfo.SetActive(true);
        }
        if(Quest.missionIndex==2)
        {
            questKeyInfo.SetActive(false);
            questText = Quest.quests[2];
            quest.text = questText;
            questKeyInfo1.SetActive(true);
        }
    }
}
