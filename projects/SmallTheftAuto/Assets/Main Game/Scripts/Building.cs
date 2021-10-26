using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IHurtOnCrash
{
    //Brinner och slutar brinna efter ett tag
    //Triggas av exploderande bilar
    //Kan sedan ta damage
    //Exploderar threshold
    public int DamageOnCrash => 10;
}