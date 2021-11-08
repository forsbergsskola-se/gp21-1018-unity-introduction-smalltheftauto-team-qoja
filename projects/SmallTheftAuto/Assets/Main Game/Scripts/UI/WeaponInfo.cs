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
        
        
        // Again, try not to call things each frame unless very necessary. 
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

    
    // In the following two examples you call two GetComponents per frame. It is recommended to get the components once at start instead. 
    private void Pistol()
    {
        _leftShots = weapons[1].GetComponent<Weapon>().bulletNumber;
        _maxShots = weapons[1].GetComponent<Weapon>().maxBullet;
        _weaponInfo.text = _leftShots + "/" + _maxShots;
        pistolImage.SetActive(true);
        smgImage.SetActive(false);

        Debug.Log("I should only be displayed once for performance reasons.");
    }

    private void Smg()
    {
        _leftShots = weapons[2].GetComponent<Weapon>().bulletNumber;
        _maxShots = weapons[2].GetComponent<Weapon>().maxBullet;
        _weaponInfo.text = _leftShots + "/" + _maxShots;
        smgImage.SetActive(true);
        pistolImage.SetActive(false);
        
        Debug.Log("I should only be displayed once for performance reasons.");
    }
}

