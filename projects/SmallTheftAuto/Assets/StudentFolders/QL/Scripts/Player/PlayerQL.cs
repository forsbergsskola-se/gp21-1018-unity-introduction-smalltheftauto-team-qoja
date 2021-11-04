using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerQL : MonoBehaviour
{
    private int health;
    private int money;
    private int score;
    private GameObject weapon;

    public int Health
    {
        get => health;
        private set
        {
            health = value;
        }
    }
    public int Money
    {
        get => money;
        private set
        {
            money = value;
        }
    }

    public int Score
    {
        get => score;
        private set
        { 
            score = value;
        }

    }

    private WeaponQL Weapon { get; set; }
    
    void Start()
    {
        Health = 2;
        Money = 100;
        Score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(1);
        }

        if (Health == 0)
        {
            Debug.Log("Player dies!");
            StartCoroutine(RestartScene());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            money -= 10;
        }
        if (Input.GetKeyDown(KeyCode.E) && Weapon==null) //Equip weapon
        {
            WeaponQL[] weapons = FindObjectsOfType<WeaponQL>();
            float[] distances = new float[weapons.Length];
            for (int i = 0; i < weapons.Length; i++)
            {
                distances[i] = Vector3.Distance(this.transform.position, weapons[i].transform.position);
            }
            int index = this.GetComponent<DriverQL>().Min(distances);
            if (distances[index] < 3)
            {
                //Equip the weapon
                this.Weapon = weapons[index];
                Debug.Log("I have the weapon "+Weapon.name+" with "+Weapon.Power+" power!");
                weapon = weapons[index].gameObject;
                weapon.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.U) && Weapon != null) //UnEquip weapon
        {
            UnEquipWeapon();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(int value)
    { 
        Health -= value;
    }

    private void UnEquipWeapon()
    {
        weapon.transform.position = this.transform.position;
        weapon.SetActive(true);
        Weapon = null;
    }
}
