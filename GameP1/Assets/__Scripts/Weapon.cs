using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Controls the player's weapon damaging enemies

    private int[] damage = { 5, 15, 25, 10 };
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the weapon collides with an enemy, the enemy takes damage or dies
        if (other.tag == "Enemy" || other.tag == "Enemy2")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            enemy.health = enemy.health - damage[Player.instance.activeWeapon];
            if (enemy.health <= 0)
            {
                Instantiate(enemy.drop, enemy.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }

        //If the weapon collides with the boss, the boss takes damage or dies
        if (other.tag == "Boss")
        {
            Boss boss = other.gameObject.GetComponent<Boss>();

            boss.health = boss.health - damage[Player.instance.activeWeapon];
            if (boss.health <= 0)
            {
                Instantiate(boss.drop, boss.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }
}
