using TMPro;
using UnityEngine;

public class Shots : MonoBehaviour
{
    private TextMeshProUGUI shots;
    private int leftShotsPistol;
    private int maxShotsPistol;
    private int leftShotsSmg;
    private int maxShotsSmg;
    public GameObject pistol;
    public GameObject smg;
    
    void Start()
    {
        shots = GetComponent<TextMeshProUGUI>();
        shots.enableAutoSizing = true;
    }

    void Update()
    {
        leftShotsPistol = pistol.GetComponent<Weapon>().bulletNumber;
        maxShotsPistol = pistol.GetComponent<Weapon>().maxBullet;
        leftShotsSmg = smg.GetComponent<Weapon2>().bulletNumber;
        maxShotsSmg = smg.GetComponent<Weapon2>().maxBullet;
        shots.text = "Pistol shots " + leftShotsPistol + "/" + maxShotsPistol+"<br>Machine gun shots "+leftShotsSmg+"/"+maxShotsSmg;
    }
}
