using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public GameObject projSprite;
    private float nextShotTime = 0;

    public override void Update()
    {
        if ((target != null) && (Time.time > nextShotTime) && (Vector3.Distance(target.position, transform.position) <= maxRange) && (Vector3.Distance(target.position, transform.position) >= minRange))
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        nextShotTime = Time.time + 2;

        GameObject projectile = Instantiate(projSprite, transform.position, transform.rotation);
        Vector3 shootLocation = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(shootLocation.normalized * 500);
    }
}
