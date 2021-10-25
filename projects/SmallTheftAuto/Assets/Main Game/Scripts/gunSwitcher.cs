using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwitcher : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchGuns();
        }
    }

    void SwitchGuns()
    {
        foreach (Transform GunHolder in transform)
        {
            GunHolder.gameObject.SetActive(!GunHolder.gameObject.activeSelf);
        }
    }
}
