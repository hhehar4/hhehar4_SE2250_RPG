using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Transform bar;

    void Start()
    {
        bar = transform.Find("Bar");
    }

    void Update()
    {
        //Updates the healthbar scale depending on the player's health
        bar.localScale = new Vector3(Player.instance.health / 100f, 1f);
    }
}
