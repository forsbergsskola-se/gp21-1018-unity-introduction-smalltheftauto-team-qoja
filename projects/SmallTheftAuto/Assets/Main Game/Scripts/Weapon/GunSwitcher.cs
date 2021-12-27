using UnityEngine;
using UnityEngine.Serialization;

public class GunSwitcher : MonoBehaviour
{
    public int currentWeaponIndex;
    public GameObject[] guns;
    [FormerlySerializedAs("GunHolder")] public GameObject gunHolder;
    public GameObject currentGun;
    private int _totalWeapons = 1;
    void Start()
    {
        _totalWeapons = gunHolder.transform.childCount;
        guns = new GameObject[_totalWeapons];

        for (int i = 0; i < _totalWeapons; i++)
        {
            guns[i] = gunHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;

    }

    void Update()
    {
        // TODO: Cool! Smart and simple!
        // Next Weapon
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeaponIndex < _totalWeapons-1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
            }
            
        }
        // Previous weapon
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
            }
            
        }
      
    }
}
