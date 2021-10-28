using TMPro;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    private TextMeshProUGUI weaponInfo;
    //public GameObject player;
    public GameObject[] weapons;
    private int leftShots;
    private int maxShots;
    public GameObject PistolImage;
    public GameObject SmgImage;

    
    void Start()
    {
        weaponInfo = GetComponent<TextMeshProUGUI>();
        weaponInfo.enableAutoSizing = true;
    }

    void Update()
    {
        if (weapons[0].activeSelf)
        {
            weaponInfo.text = "Use mouse wheel to equip weapon";
            PistolImage.SetActive(false);
            SmgImage.SetActive(false);
        }

        if (weapons[1].activeSelf)
        {
            leftShots = weapons[1].GetComponent<Weapon>().bulletNumber;
            maxShots = weapons[1].GetComponent<Weapon>().maxBullet;
            weaponInfo.text = leftShots+"/"+maxShots;
            PistolImage.SetActive(true);
            SmgImage.SetActive(false);
        } 
        if (weapons[2].activeSelf)
        {
            leftShots = weapons[2].GetComponent<Weapon>().bulletNumber;
            maxShots = weapons[2].GetComponent<Weapon>().maxBullet;
            weaponInfo.text = leftShots+"/"+maxShots;
            SmgImage.SetActive(true);
            PistolImage.SetActive(false);
        } 
        
    }
}
