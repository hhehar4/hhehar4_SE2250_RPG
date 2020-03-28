using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    //Shooting enemy script (Guardian)

    public GameObject projSprite;
    private float nextShotTime = 0;

    public override void Update()
    {
        //Checks if the player is within range
        if ((target != null) && (Time.time > nextShotTime) && (Vector3.Distance(target.position, transform.position) <= maxRange) && (Vector3.Distance(target.position, transform.position) >= minRange))
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        nextShotTime = Time.time + 2;
        //Creates a projectile at the enemy's position
        GameObject projectile = Instantiate(projSprite, transform.position, transform.rotation);
        //Gets a vector going from the enemy to the player
        Vector3 shootLocation = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        //Makes the projectile move along the vector
        rb.AddForce(shootLocation.normalized * 500);
    }
}
