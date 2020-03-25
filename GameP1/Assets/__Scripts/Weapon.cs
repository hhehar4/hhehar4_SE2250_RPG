﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int[] damage = { 5, 15, 20, 10 };
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the weapon collides with an enemy, the enemy takes damage or dies
        if (other.tag == "Enemy" || other.tag == "Enemy2")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            SpriteRenderer renderer = other.gameObject.GetComponent<SpriteRenderer>();

            enemy.health = enemy.health - damage[Player.instance.activeWeapon];
            if (enemy.health <= 0)
            {
                Destroy(other.gameObject);
                Player.instance.level++;
            }
        }
    }
}
