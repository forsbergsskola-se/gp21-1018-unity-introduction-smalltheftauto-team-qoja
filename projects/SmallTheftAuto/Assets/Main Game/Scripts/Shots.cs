using TMPro;
using UnityEngine;

public class Shots : MonoBehaviour
{
    private TextMeshProUGUI shots;
    private int leftShotsPistol;
    private int maxShotsPistol;
    private int leftShotsSmg;
    private int maxShotsSmg;
    public GameObject[] weapon;
    private int[] leftShots;
    private int[] maxShots;
    
    void Start()
    {
        shots = GetComponent<TextMeshProUGUI>();
        shots.enableAutoSizing = true;
    }

    void Update()
    {
        // for (int i = 0; i < weapon.Length; i++)
        // {
        //     leftShots[i] = weapon[i].GetComponent<Weapon>().bulletNumber;
        //     maxShots[i] = weapon[i].GetComponent<Weapon>().maxBullet;
        // }
        leftShotsPistol = weapon[0].GetComponent<Weapon>().bulletNumber;
        maxShotsPistol = weapon[0].GetComponent<Weapon>().maxBullet;
        leftShotsSmg = weapon[1].GetComponent<Weapon>().bulletNumber;
        maxShotsSmg = weapon[1].GetComponent<Weapon>().maxBullet;
        shots.text = "Pistol shots " + leftShotsPistol + "/" + maxShotsPistol+"<br>Machine gun shots "+leftShotsSmg+"/"+maxShotsSmg;
        
    }
}
