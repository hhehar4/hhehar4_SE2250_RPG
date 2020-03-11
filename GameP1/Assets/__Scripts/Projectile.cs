using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int[] damage = {5, 10, 20};
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the projectile collides with the wall, it gets destroyed
        if(other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        //If the projectile collides with an enemy, the enemy takes damage or dies and the projectile gets destroyed
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.health = enemy.health - damage[Player.instance.level];
            if (enemy.health <= 0)
            {
                Destroy(other.gameObject);
                if(Player.instance.level < 2)
                {
                    Player.instance.level++;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
    