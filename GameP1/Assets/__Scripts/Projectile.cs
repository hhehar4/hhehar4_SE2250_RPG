using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Control's player shot projectiles

    private int[] damage = {5, 10, 20};
    private float[] multiplier = { 1, 1.5f};
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
                Instantiate(enemy.drop, enemy.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
        //If the projectile collides with the boss, the boss takes damage or dies and the projectile gets destroyed
        if (other.tag == "Boss")
        {
            Boss boss = other.gameObject.GetComponent<Boss>();
            boss.health = boss.health - (damage[Player.instance.level] * ((int)multiplier[Player.instance.activeWeapon / 3]));
            if (boss.health <= 0)
            {
                Instantiate(boss.drop, boss.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
    