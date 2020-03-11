using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Singleton class to keep track of player stats
    public static Player instance = null;
    public GameObject player = null;
    public int health = 100;
    public int level = 0;
    public int activeWeapon = 0;
    public bool[] currentWeapons = { true, false, false, false};
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
