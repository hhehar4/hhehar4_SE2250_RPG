using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        //On collision with the player, the player takes damage or dies
        if (collision.collider.tag == "Player")
        {
            Player.instance.health = Player.instance.health - 20;
            Debug.Log(Player.instance.health);
            if (Player.instance.health <= 0)
            {
                Destroy(collision.gameObject);
                target = null;
            }
        }
    }
}
