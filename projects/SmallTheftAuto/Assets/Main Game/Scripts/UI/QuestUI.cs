using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public GameObject questKeyInfo;
    public GameObject questKeyInfo1;
    private TextMeshProUGUI _quest;
    private string _questText;
    
    private void Start()
    {
        _quest = GetComponent<TextMeshProUGUI>();
        _quest.enableAutoSizing = true;
    }

    private void Update()
    {
        
        
        // This should probably not be called every frame for performance reasons. Try setting it once when you activate the quest instead.
        QuestText(Quest.MissionIndex);
        
        
        
        //When there is no more quests
        if (Quest.MissionIndex==Quest.Quests.Length - 1)
        {
            NoMoreQuests();
        }
    }

    //Shows quest instructions
    private void QuestText(int i)
    {
        if (Player.QuestIsActive)
        {
            DisplayQuest(i);
        }
    }

    private void NoMoreQuests()
    {
        questKeyInfo.SetActive(false);
        _questText = Quest.Quests[Quest.Quests.Length - 1];
        _quest.text = _questText;
        questKeyInfo1.SetActive(true);
    }

    private void DisplayQuest(int i)
    {
        _questText = Quest.Quests[i];
        _quest.text = _questText;
        questKeyInfo.SetActive(true);
        questKeyInfo1.SetActive(false); 
    }
}