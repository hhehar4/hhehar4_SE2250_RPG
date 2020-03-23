using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the projectile collides with the wall, it gets destroyed
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        //If the projectile collides with an enemy, the enemy takes damage or dies and the projectile gets destroyed
        if (other.tag == "Player")
        {
            Player.instance.health = Player.instance.health - 10;
            if (Player.instance.health <= 0)
            {
                Player.instance.Respawn();
            }
            Destroy(this.gameObject);
        }
    }
}
