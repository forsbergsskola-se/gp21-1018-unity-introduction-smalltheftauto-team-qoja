using TMPro;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public GameObject pistolImage;
    public GameObject smgImage;
    public GameObject[] weapons;
    private TextMeshProUGUI _weaponInfo;
    private int _leftShots;
    private int _maxShots;

    void Start()
    {
        _weaponInfo = GetComponent<TextMeshProUGUI>();
        _weaponInfo.enableAutoSizing = true;
    }

    void Update()
    {
        if (weapons[0].activeSelf)
        {
            NoWeapon();
        }

        if (weapons[1].activeSelf)
        {
            Pistol();
        } 
        
        if (weapons[2].activeSelf)
        {
            Smg();
        }
    }

    private void NoWeapon()
    {
        _weaponInfo.text = "Use mouse wheel to equip weapon";
        pistolImage.SetActive(false);
        smgImage.SetActive(false);
    }

    private void Pistol()
    {
        _leftShots = weapons[1].GetComponent<Weapon>().bulletNumber;
        _maxShots = weapons[1].GetComponent<Weapon>().maxBullet;
        _weaponInfo.text = _leftShots + "/" + _maxShots;
        pistolImage.SetActive(true);
        smgImage.SetActive(false);
    }

    private void Smg()
    {
        _leftShots = weapons[2].GetComponent<Weapon>().bulletNumber;
        _maxShots = weapons[2].GetComponent<Weapon>().maxBullet;
        _weaponInfo.text = _leftShots + "/" + _maxShots;
        smgImage.SetActive(true);
        pistolImage.SetActive(false);
    }
}

