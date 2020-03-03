using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;
    public GameObject player;
    public int health = 100;
    public int level = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
