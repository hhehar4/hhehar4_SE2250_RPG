using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUps : MonoBehaviour
{
    public GameObject[] weapons;
    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player walks over the weapon pickups, the weapon is removed from the map and enabled in the player's inventory
        if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
            Player.instance.currentWeapons[id] = true;
        }
    }
}
