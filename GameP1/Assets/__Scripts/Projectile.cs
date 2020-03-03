using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int[] damage = {5, 10, 20};
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.health = enemy.health - damage[Player.instance.level];
            if (enemy.health <= 0)
            {
                Destroy(other.gameObject);
                Player.instance.level++;
            }
            Destroy(this.gameObject);
        }
    }
}
    