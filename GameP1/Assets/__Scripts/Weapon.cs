using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int[] damage = { 5, 20, 10, 15 };
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.health = enemy.health - damage[Player.instance.activeWeapon];
            if (enemy.health <= 0)
            {
                Destroy(other.gameObject);
                Player.instance.level++;
            }
        }
    }
}
