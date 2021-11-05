using UnityEngine;

public class Player : MonoBehaviour, IHaveHealth
{
    [SerializeField] public int maxHealth = 100;
    public GameObject questUI;
    public static bool QuestIsActive;
    private int _health;
    private GameObject _quest;

    private void Awake()
    {
        _health = maxHealth;
    }
    
    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, maxHealth);
    }
    
    public static int Money { get; set; }

    public int Score { get; set; }

    private bool IsAlive => _health > 0;

    public bool IsDead => !IsAlive;

    private void Update()
    {
        QuestFinder();
        
    }

    //Following method should be moved out of playerscript
    private void QuestFinder()
    {
        if (Input.GetKeyDown(KeyCode.E) && !QuestIsActive)
        {
            Quest[] quests = FindObjectsOfType<Quest>();
            float[] distances = new float[quests.Length];
            
            for (int i = 0; i < quests.Length; i++)
            {
                distances[i] = Vector2.Distance(transform.position, quests[i].transform.position);
            }
            
            int index = FindObject.FindIndexOfClosestObject(distances);
            
            if (distances[index] < 4)
            {
                _quest = quests[index].gameObject;
                questUI.SetActive(true);
                QuestIsActive = true;
            }
        }
    }
    
    
}
