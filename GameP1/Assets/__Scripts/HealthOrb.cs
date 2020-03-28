using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    //Controls health orbs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //On collision with the player, heals the player for 20 health
        if (collision.tag == "Player")
        {
            Player.instance.health += 20;
            if (Player.instance.health > 100)
            {
                Player.instance.health = 100;
            }
            Destroy(this.gameObject);
        }
    }
}
