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
        QuestText(Quest.missionIndex);
        if(Quest.missionIndex==Quest.quests.Length-1)
        {
            questKeyInfo.SetActive(false);
            questText = Quest.quests[Quest.quests.Length-1];
            quest.text = questText;
            questKeyInfo1.SetActive(true);
        }
    }

    void QuestText(int i)
    {
        if (Player.questIsActive)
        {
            questText = Quest.quests[i];
            quest.text = questText;
            questKeyInfo.SetActive(true);
            questKeyInfo1.SetActive(false); 
        }
    }
}
